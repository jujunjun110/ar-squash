using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.UIElements.StyleEnums;
using UnityEngine.XR.iOS;

public class CursorController : MonoBehaviour {
    [SerializeField] private Transform m_HitTransform;

    [SerializeField] private GameObject PolePrefab;


    void UpdateTransform(Vector3 pos, Quaternion rot) {
        if (Input.touchCount <= 0) {
            return;
        }

        var touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Began && touch.phase != TouchPhase.Moved) {
            Debug.Log($"Touched.");
            var pole = Instantiate(PolePrefab);
            var poleHeight = PolePrefab.transform.localScale.y;
            pole.transform.position = new Vector3(pos.x, pos.y + poleHeight, pos.z);
            pole.transform.rotation = rot;
        }
    }
}