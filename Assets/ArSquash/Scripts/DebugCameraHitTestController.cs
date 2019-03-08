using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCameraHitTestController : MonoBehaviour {
    [SerializeField] private float maxRayDistance = 30.0f;
    [SerializeField] private LayerMask collisionLayer = 1 << 10; //ARKitPlane layer
    [SerializeField] private GameObject cursorObject;

    void Update() {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit, maxRayDistance, collisionLayer)) {
            return;
        }

        cursorObject.transform.position = hit.point;
        cursorObject.transform.rotation = hit.transform.rotation;
    }
}