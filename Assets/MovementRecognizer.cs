using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
//using UnityEngine.InputSystem;
using PDollarGestureRecognizer;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
using System.IO; 

public class MovementRecognizer : MonoBehaviour
{
    public XRNode inputSource;
    public InputHelpers.Button inputButton;
    public float inputThreshold = 0.1f;
    public Transform movementSource;
    public bool creationMode = true;
    public string newGestureName;
    public GameObject cube;
    public float newPositionThresholdDistance = 0.05f;

    [System.Serializable]
    public class UnityStringEvent : UnityEvent<string> { }
    public UnityStringEvent OnGestureRecognized;
 
    private bool isMoving = false;   
    private List<Gesture> trainingSet = new List<Gesture>();
    private List<Vector3> positionList = new List<Vector3>();
    

    void Start() {
        string[] gestureFiles = Directory.GetFiles(Application.persistentDataPath, "*.xml");
        foreach(string fileName in gestureFiles) {
            trainingSet.Add(GestureIO.ReadGestureFromFile(fileName));
        }
    }

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
        positionList.Clear();
        positionList.Add(movementSource.position);
        if (cube)
            Destroy(Instantiate(cube, movementSource.position, Quaternion.identity),3);
    }  

    void StopMoving() {
        isMoving = false;
        Debug.Log("Stopped Moving");
        Point[] pointArray = new Point[positionList.Count];
        for(int i = 0; i < positionList.Count; i++) {
            //pointArray[i] = new Point(positionList[i].x, positionList[i].y, positionList[i].z);
            Vector2 point = Camera.main.WorldToScreenPoint(positionList[i]);
            pointArray[i] = new Point(point.x, point.y, 0);
        }

        Gesture newGesture = new Gesture(pointArray);
        if (creationMode) {
            newGesture.Name = newGestureName;
            trainingSet.Add(newGesture);

            string fileName = Application.persistentDataPath + "/" + newGestureName + ".xml";
            GestureIO.WriteGesture(pointArray, newGestureName, fileName);
        } else {
            Result gestureResult = PointCloudRecognizer.Classify(newGesture, trainingSet.ToArray());
            Debug.Log("[Gesture] Gesture: " + gestureResult.GestureClass + "; Score: " + gestureResult.Score);
            if(gestureResult.Score > 0.7f) {
                OnGestureRecognized.Invoke(gestureResult.GestureClass);
            }
        }
    }   
    void UpdateMoving() {
        Debug.Log("Still Moving");
        Vector3 lastPosition = positionList[positionList.Count - 1];
        if(Vector3.Distance(movementSource.position, lastPosition) > newPositionThresholdDistance) {
            positionList.Add(movementSource.position);
            if (cube)
                Destroy(Instantiate(cube, movementSource.position, Quaternion.identity),3);
        }
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
