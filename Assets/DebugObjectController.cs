using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugObjectController : MonoBehaviour {
    [SerializeField] private GameObject arCamera;
//    [SerializeField] private GameObject debugFloor;

    void Start() {
        if (Application.isEditor) {
            arCamera.SetActive(false);
//            debugFloor.SetActive(true);
            foreach (Transform child in transform) {
                child.gameObject.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update() {
    }
}