using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AppUtil {
    public static bool Touched() {
        if (Application.isEditor) {
            // Editor
            return Input.GetMouseButtonUp(0);
        }

        // SmartPhone
        return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended;
    }
}