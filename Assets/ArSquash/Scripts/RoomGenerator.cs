using System;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour {
    [SerializeField] private GameObject cursorObject;
    [SerializeField] private GameObject polePrefab;
    [SerializeField] private GameObject room;
    [SerializeField] private GameObject wallPrefab;

    private List<Transform> tappedPoints = new List<Transform>();


    private void Update() {
        if (!AppUtil.Touched()) {
            return;
        }

        var copied = new GameObject().transform;
        copied.position = cursorObject.transform.position;
        copied.rotation = cursorObject.transform.rotation;
        tappedPoints.Add(copied);

        GeneratePole();
        var pointNum = tappedPoints.Count;
        if (pointNum < 2) {
            return;
        }

        var point1 = tappedPoints[pointNum - 2].position;
        var point2 = tappedPoints[pointNum - 1].position;
        GenerateMesh(point1, point2);
    }

    private void GeneratePole() {
        var poleHeight = polePrefab.transform.localScale.y;
        Instantiate(
            polePrefab,
            cursorObject.transform.position + Vector3.up * poleHeight,
            cursorObject.transform.rotation,
            room.transform
        );
    }

    private void GenerateMesh(Vector3 p1, Vector3 p2) {
        var wall = Instantiate(wallPrefab, room.transform);
        var trans = GetWallTransform(p1, p2, wallPrefab);
        wall.transform.position = trans.position;
        wall.transform.localScale = trans.localScale;
        wall.transform.rotation = trans.rotation;
    }

    public static Transform GetWallTransform(Vector3 p1, Vector3 p2, GameObject targetObject) {
        var mid = (p1 + p2) / 2;
        var tan = (p1.z - p2.z) / (p1.x - p2.x);
        var horizontal_rot = -Mathf.Rad2Deg * Mathf.Atan(tan);
        var distance = Vector3.Distance(p1, p2);

        var ret = new GameObject().transform;
        ret.transform.position = mid + Vector3.up * targetObject.transform.localScale.y / 2;
        ret.transform.localScale = targetObject.transform.localScale + Vector3.right * (distance - 1);
        ret.transform.rotation = Quaternion.Euler(0, horizontal_rot, 0);
        return ret;
    }
}