using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrRigReferences : MonoBehaviour
{
    public static VrRigReferences Singelton;

    public Transform head;
    public Transform root;

    private void Awake()
    {
        Singelton = this;
    }

}
