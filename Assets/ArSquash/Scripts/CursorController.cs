using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.iOS;

public class CursorController : MonoBehaviour {
    [SerializeField] private Transform m_HitTransform;

    [SerializeField] private GameObject PolePrefab;
//    public float maxRayDistance = 30.0f;
//    public LayerMask collisionLayer = 1 << 10; //ARKitPlane layer


    void Update() {
//#if UNITY_EDITOR //we will only use this script on the editor side, though there is nothing that would prevent it from working on device
//        if (!Input.GetMouseButtonDown(0)) {
//            return;
//        }
//
//        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//        RaycastHit hit;
//
//        //we'll try to hit one of the plane collider gameobjects that were generated by the plugin
//        //effectively similar to calling HitTest with ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent
//        if (!Physics.Raycast(ray, out hit, maxRayDistance, collisionLayer)) {
//            return;
//        }
//
//        //we're going to get the position from the contact point
//        m_HitTransform.position = hit.point;
//        Debug.Log(string.Format("x:{0:0.######} y:{1:0.######} z:{2:0.######}", m_HitTransform.position.x,
//            m_HitTransform.position.y, m_HitTransform.position.z));
//
//        //and the rotation from the transform of the plane collider
//        m_HitTransform.rotation = hit.transform.rotation;
//#else


        var hitResults = UnityARSessionNativeInterface.GetARSessionNativeInterface()
            .HitTest(new ARPoint {x = 0.5, y = 0.5}, ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent);

        if (!m_HitTransform || hitResults.Count <= 0) {
            return;
        }

        var hitResult = hitResults.First();

        m_HitTransform.position = UnityARMatrixOps.GetPosition(hitResult.worldTransform);
        m_HitTransform.rotation = UnityARMatrixOps.GetRotation(hitResult.worldTransform);

        if (Input.touchCount <= 0) {
            return;
        }

        var touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Began && touch.phase != TouchPhase.Moved) {
            Debug.Log($"Touched.");
            var pole = Instantiate(PolePrefab);
            var poleHeight = PolePrefab.transform.localScale.y;
            var _pos = UnityARMatrixOps.GetPosition(hitResult.worldTransform);
            pole.transform.position = new Vector3(_pos.x, _pos.y + poleHeight, _pos.z);
            pole.transform.rotation = UnityARMatrixOps.GetRotation(hitResult.worldTransform);
        }
    }
}