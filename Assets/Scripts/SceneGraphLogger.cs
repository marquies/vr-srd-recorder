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
        Debug.Log("--- Start Scene Graph ---");
        foreach (GameObject obj in rootObjects)
        {
            LogGameObject(obj, 0);
        }
        Debug.Log("--- End Scene Graph ---");
        /*string output = "";
        foreach (GameObject obj in rootObjects)
        {
                output = output + GameObjectsAsString(obj, 0);
        }
        Debug.Log(output);*/
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
        string output = "";
        foreach (GameObject obj in rootObjects)
        {
                output = output + GameObjectsAsString(obj, 0);
        }
        Debug.Log(output);

    }

    void LogGameObject(GameObject obj, int depth)
    {
        string indent = new string(' ', depth * 2);
        Renderer renderer = obj.GetComponent<Renderer>();
        string output = "";
        if (renderer != null && renderer.isVisible)
        {
            output = $"1 {indent}{obj.name}";
        } else if (renderer != null) {
            output = $"2 {indent}{obj.name}";
        } else if (renderer == null) {
            output = $"3 {indent}{obj.name}";
        }
        Debug.Log(output);

        foreach (Transform child in obj.transform)
        {
            LogGameObject(child.gameObject, depth + 1);
        }
    }
    string GameObjectsAsString(GameObject obj, int depth)
    {
        string indent = new string(' ', depth * 2);
        Renderer renderer = obj.GetComponent<Renderer>();
        string output = "";
        if (renderer != null && renderer.isVisible)
        {
            output = $"1 {indent}{obj.name} \n";
        } else if (renderer != null) {
            output = $"2 {indent}{obj.name} \n";
        } else if (renderer == null) {
            output = $"3 {indent}{obj.name} \n";
        }

        foreach (Transform child in obj.transform)
        {
            output = output + GameObjectsAsString(obj, 0);
        }
        return output;
        //Debug.Log(output);
    }
}