using System.Linq;
using UnityEngine;
using UnityEngine.XR.iOS;

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
        if (GameManager.RoomGenerated) {
            return;
        }

        cursorObject.transform.position = UnityARMatrixOps.GetPosition(hitResult.worldTransform);
        cursorObject.transform.rotation = UnityARMatrixOps.GetRotation(hitResult.worldTransform);
    }
}