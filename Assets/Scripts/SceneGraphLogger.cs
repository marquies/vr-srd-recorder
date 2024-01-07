using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneGraphLogger : MonoBehaviour
{
    public InputActionReference m_ToggleSceneGraphLoggerAction;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        GameObject[] rootObjects = currentScene.GetRootGameObjects();

        foreach (GameObject obj in rootObjects)
        {
            LogGameObject(obj, 0);
        }
    }

    private void Awake()
    {
        Debug.Log("Awake");
        m_ToggleSceneGraphLoggerAction.action.started += Toogle;
    }

    private void OnDestroy()
    {
        Debug.Log("OnDestroy");
        m_ToggleSceneGraphLoggerAction.action.started += Toogle;
    }

    private void Toogle(InputAction.CallbackContext context)
    {
        bool isActive = gameObject.activeSelf;
        gameObject.SetActive(!isActive);
        Scene currentScene = SceneManager.GetActiveScene();
        GameObject[] rootObjects = currentScene.GetRootGameObjects();

        foreach (GameObject obj in rootObjects)
        {
                LogGameObject(obj, 0);
        }
    }

    void LogGameObject(GameObject obj, int depth)
    {
        string indent = new string(' ', depth * 2);
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null && renderer.isVisible)
        {
            Debug.Log($"1 {indent}{obj.name}");
        } else if (renderer != null) {
            Debug.Log($"2 {indent}{obj.name}");
        } else if (renderer == null) {
            Debug.Log("renderer null");
        }

        //Debug.Log($"2 {indent}{obj.name}");

        foreach (Transform child in obj.transform)
        {
            LogGameObject(child.gameObject, depth + 1);
        }
    }
}