using UnityEngine;

public class DebugCameraHitTestController : MonoBehaviour {
    [SerializeField] private float maxRayDistance = 3000.0f;
    [SerializeField] private LayerMask collisionLayer = 1 << 10; //ARKitPlane layer
    [SerializeField] private GameObject cursorObject;

    void Update() {
        var layerMask = ~collisionLayer;

        RaycastHit hit;
        var fwd = transform.TransformDirection(Vector3.forward);
        if (!Physics.Raycast(transform.position, fwd, out hit, maxRayDistance, layerMask)) {
            return;
        }

        cursorObject.transform.position = hit.point;
        cursorObject.transform.rotation = hit.transform.rotation;
    }
}