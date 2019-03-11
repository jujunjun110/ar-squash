using UnityEngine;

public class RoomGenerator : MonoBehaviour {
    [SerializeField] private GameObject cursorObject;
    [SerializeField] private GameObject polePrefab;
    [SerializeField] private GameObject room;


    void Update() {
        if (!AppUtil.Touched()) {
            return;
        }

        var poleHeight = polePrefab.transform.localScale.y;
        var pos = cursorObject.transform.position;


        Instantiate(
            polePrefab,
            new Vector3(pos.x, pos.y + poleHeight, pos.z),
            cursorObject.transform.rotation,
            room.transform
        );
    }
}