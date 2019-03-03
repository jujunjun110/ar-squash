using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;
public class RoomDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
//        planeAnchorMap = new LinkedListDictionary<string,ARPlaneAnchorGameObject> ();
        UnityARSessionNativeInterface.ARAnchorAddedEvent += AddAnchor;
//        UnityARSessionNativeInterface.ARAnchorUpdatedEvent += UpdateAnchor;
//        UnityARSessionNativeInterface.ARAnchorRemovedEvent += RemoveAnchor;       
    }

    void AddAnchor(ARPlaneAnchor arPlaneAnchor)
    {
        Debug.Log("anchor added");
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}

