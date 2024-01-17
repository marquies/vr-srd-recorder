    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
//using UnityEngine.InputSystem;

using UnityEngine.XR.Interaction.Toolkit;

public class MovementRecognizer : MonoBehaviour
{

    
public XRNode inputSource;
public InputHelpers.Button inputButton;
public float inputThreshold = 0.1f;

private bool isMoving = false;

    //public InputActionReference m_ToggleSceneGraphLoggerAction;
//public UnityEngine.XR.Interaction.Toolkit.InputHelpers.Button inputButton;
//public float inputThreshold = 0.1f;
    //public InputActionReference m_ToggleSceneGraphLoggerAction;
/*
    private bool isPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }
       private void Awake()
    {
        Debug.Log("Awake");
        //m_ToggleSceneGraphLoggerAction.action.started += StartMoving;
        //m_ToggleSceneGraphLoggerAction.action.performed += StopMoving;
    }

    private void OnDestroy()
    {
        Debug.Log("OnDestroy");
        //m_ToggleSceneGraphLoggerAction.action.started += Toggle;
    }

    private void OnEnable()
    {
        m_ToggleSceneGraphLoggerAction.action.started += OnButtonPress;
        m_ToggleSceneGraphLoggerAction.action.performed += OnButtonRelease;
        m_ToggleSceneGraphLoggerAction.action.canceled += OnButtonRelease;
    }

    private void OnDisable()
    {
        m_ToggleSceneGraphLoggerAction.action.started -= OnButtonPress;
        m_ToggleSceneGraphLoggerAction.action.performed -= OnButtonRelease;
        m_ToggleSceneGraphLoggerAction.action.canceled -= OnButtonRelease;
    }
*/
   /* private void OnButtonPress(InputAction.CallbackContext context)
    {
        isPressed = true;
        StartCoroutine(LogPosition());
    }

    private void OnButtonRelease(InputAction.CallbackContext context)
    {
        isPressed = false;
        //StopCoroutine(LogPosition());
    }

    private IEnumerator LogPosition()
    {
        while (isPressed)
        {
            //Vector3 controllerPosition = positionActionReference.action.ReadValue<Vector3>();
            Debug.Log("Controller Position"); //: " + controllerPosition);
            yield return null;
        }
    }*/

//    private void Toogle(InputAction.CallbackContext context)

    // Update is called once per frame
  //  void Toggle(InputAction.CallbackContext context)
   // {
/*        UnityEngine.XR.Interaction.Toolkit.InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), inputButton, out bool isPressed, inputThreshold);
*/  
     //   Debug.Log("Update");
/*
        if(!isMoving && isPressed) {
            StartMoving();
        } else if(isMoving && !isPressed) {
            StopMoving();
        } else if(isMoving && isPressed) {
            UpdateMoving();  
        } else if(!isMoving && !isPressed) {
            //Debug.Log("Still Not Moving");
        }*/
 //  }

    void StartMoving() {
        Debug.Log("Moving");
           isMoving = true;
            Debug.Log("Moving");
    }  

    void StopMoving() {
            isMoving = false;
            Debug.Log("Not Moving");
    }   
    void UpdateMoving() {
        Debug.Log("Still Moving");
    }


   //  public XRController controller;
    private Vector3 lastPosition;
    private bool isSwiping = false;

    void Update()
    {
        
        
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), inputButton, out bool isPressed, inputThreshold);

        if(!isMoving && isPressed) {
            StartMoving();
        } else if(isMoving && !isPressed) {
            StopMoving();
        } else if(isMoving && isPressed) {
            UpdateMoving();  
        //} else if(!isMoving && !isPressed) {
        //    Debug.Log("Still Not Moving");
        }


       /*
        if (controller)
        {
            Debug.Log("Swipe Debug 1");
            if (controller.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerValue) && triggerValue)
            {
                Debug.Log("Swipe Debug 2");
                if (!isSwiping)
                {
                    isSwiping = true;
                    lastPosition = controller.transform.position;
                }
                else
                {
                    Vector3 currentPosition = controller.transform.position;
                    Vector3 direction = currentPosition - lastPosition;

                    if (direction.magnitude > 50) // Define your threshold
                    {
                        // Swipe detected
                        HandleSwipe(direction);
                    }

                    lastPosition = currentPosition;
                }
            }
            else
            {
                isSwiping = false;
            }
        }*/
    }

    private void HandleSwipe(Vector3 direction)
    {
        // Handle the swipe gesture (e.g., navigate menus, turn pages, etc.)
        Debug.Log("Swiped");

    }
}
