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

        Debug.Log("TOUCHED");

        GeneratePole();
    }

    private void GeneratePole() {
        var poleHeight = polePrefab.transform.localScale.y;
        var pos = cursorObject.transform.position;
        Instantiate(
            polePrefab,
            new Vector3(pos.x, pos.y + poleHeight, pos.z),
            cursorObject.transform.rotation,
            room.transform
        );

        var copied = new GameObject().transform;
        copied.position = cursorObject.transform.position;
        copied.rotation = cursorObject.transform.rotation;

        tappedPoints.Add(copied);
        Debug.Log(tappedPoints.Count);
        var pointNum = tappedPoints.Count;
        if (pointNum >= 2) {
            foreach (var p in tappedPoints) {
                Debug.Log(p.position);
            }

            var point1 = tappedPoints[pointNum - 2].position;
            var point2 = tappedPoints[pointNum - 1].position;
            var point3 = new Vector3(point1.x, point1.y + 2, point1.z);
            GenerateMesh(point1, point2, point3);
        }
    }

    void GenerateMesh(Vector3 p1, Vector3 p2, Vector3 p3) {
        foreach (var pos in new[] {p1, p2, p3}) {
            Debug.Log(pos);
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = pos;
        }


        var mesh = new Mesh {
            vertices = new Vector3[] {
                p1,
                p2,
                p3,
            },
            triangles = new int[] {0, 1, 2}
        };

        mesh.RecalculateNormals();
        var filter = GetComponent<MeshFilter>();
        filter.sharedMesh = mesh;
    }
}