using UnityEngine;

public class CursorController : MonoBehaviour {
    [SerializeField] private GameObject PolePrefab;

    void Update() {
        if (!touchEnd()) {
            return;
        }

        var pole = Instantiate(PolePrefab);
        var poleHeight = PolePrefab.transform.localScale.y;
        var pos = transform.position;
        pole.transform.localPosition = new Vector3(pos.x, pos.y + poleHeight, pos.z);
        pole.transform.rotation = transform.rotation;
    }

    bool touchEnd() {
        if (Application.isEditor) {
            return Input.GetMouseButtonUp(0);
        }

        if (Input.touchCount <= 0) {
            return false;
        }

        var touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved) {
            return false;
        }

        return true;
    }
}