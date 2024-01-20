using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrRigReferences : MonoBehaviour
{
    public static VrRigReferences Singelton;

    public Transform head;
    public Transform root;
    public Transform leftHand;
    public Transform rightHand;

    public Transform emoticon;

    private void Awake()
    {
        Singelton = this;
    }

}
