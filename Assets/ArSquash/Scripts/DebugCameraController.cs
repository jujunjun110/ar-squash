using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCameraController : MonoBehaviour {
    [SerializeField] private float speed = 10.0f;
    [SerializeField] public float horizontalSpeed = 2.0F;
    [SerializeField] public float verticalSpeed = 2.0F;


    void Update() {
        if (Input.GetAxis("Mouse X") == 0) {
            return;
        }

        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("MouseDown");
            transform.position += new Vector3(
                Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
                0.0f,
                Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed
            );
        } else {
            Debug.Log("MouseUp");
            transform.Rotate(
                verticalSpeed * Input.GetAxis("Mouse Y"),
                horizontalSpeed * Input.GetAxis("Mouse X"),
                0
            );
        }
    }
}