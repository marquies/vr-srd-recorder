using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetworkPlayer : NetworkBehaviour
{
    public Transform root;
    public Transform head;

    public Renderer[] meshToDisable;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        Debug.Log("NetworkPlayer OnNetworkSpawn");
        if (IsOwner) {
          foreach(var item in meshToDisable) {
              item.enabled = false;
          }
        }
     
    }

    // Start is called before the first frame update
    //void Start()
    //{
       // transform.position += new Vector3(0,0.5f,0);
      //  Debug.Log("NetworkPlayer Start");
    //}

    // Update is called once per frame
    void Update()
    {
        if(IsOwner) {

            root.position = VrRigReferences.Singelton.head.position;
            root.rotation = VrRigReferences.Singelton.head.rotation;       

            head.position = VrRigReferences.Singelton.head.position;
            head.rotation = VrRigReferences.Singelton.head.rotation;
        }
    }
}
