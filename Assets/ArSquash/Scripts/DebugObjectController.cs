using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugObjectController : MonoBehaviour {
    [SerializeField] private GameObject arCamera;

    void Start() {
        if (Application.isEditor) {
            ActivateDebugObjects();
        } else {
            InActivateDebugObjects();
        }
    }

    private void ActivateDebugObjects() {
        arCamera.SetActive(false);
        foreach (Transform child in transform) {
            child.gameObject.SetActive(true);
        }
    }

    private void InActivateDebugObjects() {
        arCamera.SetActive(true);
        foreach (Transform child in transform) {
            child.gameObject.SetActive(false);
        }
    }
}