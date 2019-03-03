using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.iOS;
public class RoomDetector : MonoBehaviour
{
    private UnityARAnchorManager unityARAnchorManager;

    void Start()
    {
        unityARAnchorManager = new UnityARAnchorManager();
        UnityARUtility.InitializePlanePrefab (new GameObject());
        UnityARSessionNativeInterface.ARAnchorAddedEvent += AddAnchor;
    }

    void OnDestroy()
    {
        unityARAnchorManager.Destroy ();
    }

    void AddAnchor(ARPlaneAnchor arPlaneAnchor)
    {
        Debug.Log(arPlaneAnchor.center);
        Debug.Log(arPlaneAnchor.transform);
        IEnumerable<ARPlaneAnchorGameObject> arpags = unityARAnchorManager.GetCurrentPlaneAnchors();
        
        var planeCount = arpags.Count();
        
        Debug.Log(planeCount);

        if (planeCount > 3)
        {
            Debug.Log("Enough Plane Detected.");
        }
    }
}

