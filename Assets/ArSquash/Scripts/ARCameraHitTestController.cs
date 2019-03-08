using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;
using System.Linq;

public class ARCameraHitTestController : MonoBehaviour {
    [SerializeField] private GameObject cursorObject;

    // Update is called once per frame
    void Update() {
        var hitResults = UnityARSessionNativeInterface.GetARSessionNativeInterface()
            .HitTest(new ARPoint {x = 0.5, y = 0.5}, ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent);

        if (hitResults.Count <= 0) {
            return;
        }

        var hitResult = hitResults.First();

        cursorObject.transform.position = UnityARMatrixOps.GetPosition(hitResult.worldTransform);
        cursorObject.transform.rotation = UnityARMatrixOps.GetRotation(hitResult.worldTransform);
    }
}