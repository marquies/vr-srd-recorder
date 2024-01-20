using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetworkPlayer : NetworkBehaviour
{
    public Transform root;
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;

    public Renderer[] meshToDisable;

    [SerializeField] 
    private Transform spawnedObjectPrefab;

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
        if(Input.GetKeyDown(KeyCode.O)) {
            Transform spawnedObjectTransform = Instantiate(spawnedObjectPrefab);
            spawnedObjectTransform.GetComponent<NetworkObject>().Spawn(true);
        }
        if(!IsOwner) return;

        root.position = VrRigReferences.Singelton.head.position;
        root.rotation = VrRigReferences.Singelton.head.rotation;       

        head.position = VrRigReferences.Singelton.head.position;
        head.rotation = VrRigReferences.Singelton.head.rotation;

        leftHand.position = VrRigReferences.Singelton.leftHand.position;
        leftHand.rotation = VrRigReferences.Singelton.leftHand.rotation;

        rightHand.position = VrRigReferences.Singelton.rightHand.position;
        rightHand.rotation = VrRigReferences.Singelton.rightHand.rotation;


    }
}
