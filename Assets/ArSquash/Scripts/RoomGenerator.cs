using UnityEngine;

public class RoomGenerator : MonoBehaviour {
    [SerializeField] private GameObject cursorObject;
    [SerializeField] private GameObject polePrefab;

    void Update() {
        if (!AppUtil.Touched()) {
            return;
        }

        var pole = Instantiate(polePrefab);
        var poleHeight = polePrefab.transform.localScale.y;
        var pos = cursorObject.transform.position;
        pole.transform.position = new Vector3(pos.x, pos.y + poleHeight, pos.z);
        pole.transform.rotation = cursorObject.transform.rotation;
    }
}