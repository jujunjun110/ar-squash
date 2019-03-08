using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCameraController : MonoBehaviour {
    [SerializeField] private float speed = 10.0f;

    void Update() {
        if (Input.GetAxis("Mouse X") == 0) {
            return;
        }

        transform.position += new Vector3(
            Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
            0.0f,
            Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed
        );
    }
}