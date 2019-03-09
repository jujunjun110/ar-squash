using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour {
    [SerializeField] private GameObject cursorObject;
    [SerializeField] private GameObject polePrefab;

    void Update() {
        if (!Touched()) {
            return;
        }

        var pole = Instantiate(polePrefab);
        var poleHeight = polePrefab.transform.localScale.y;
        var pos = cursorObject.transform.position;
        pole.transform.position = new Vector3(pos.x, pos.y + poleHeight, pos.z);
        pole.transform.rotation = cursorObject.transform.rotation;
    }

    bool Touched() {
        if (Application.isEditor) {
            // Editor
            return Input.GetMouseButtonUp(0);
        }

        // SmartPhone
        return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended;
    }
}