using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Vuforia;

public class RoomGenerator : MonoBehaviour {
    [SerializeField] private GameObject cursorObject;
    [SerializeField] private GameObject polePrefab;
    [SerializeField] private GameObject room;

    private List<Transform> tappedPoints = new List<Transform>();


    void Update() {
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

    void GenerateMesh(Vector3 p1, Vector3 p2) {
        var p3 = p1 + Vector3.up * 2;
        var p4 = p1 + Vector3.up * 2;

        foreach (var pos in new[] {p1, p2, p3, p4}) {
            Debug.Log(pos);
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            cube.transform.position = pos;
        }


        var mesh = new Mesh {
            vertices = new[] {p1, p2, p3},
            triangles = new[] {0, 1, 2}
        };

        mesh.RecalculateNormals();
        var filter = GetComponent<MeshFilter>();
        filter.sharedMesh = mesh;
    }
}