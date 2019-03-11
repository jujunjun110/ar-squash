using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugObjectController : MonoBehaviour {
    [SerializeField] private GameObject arCamera;

    private void Start() {
        if (Application.isEditor) {
            ActivateDebugObjects();
        } else {
            InactivateDebugObjects();
        }
    }

    private void ActivateDebugObjects() {
        arCamera.SetActive(false);
        foreach (Transform child in transform) {
            child.gameObject.SetActive(true);
        }
    }

    private void InactivateDebugObjects() {
        arCamera.SetActive(true);
        foreach (Transform child in transform) {
            child.gameObject.SetActive(false);
        }
    }
}