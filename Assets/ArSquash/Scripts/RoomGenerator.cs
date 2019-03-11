﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomGenerator : MonoBehaviour {
    [SerializeField] private GameObject cursorObject;
    [SerializeField] private GameObject polePrefab;
    [SerializeField] private GameObject room;

    private List<Transform> tappedPoints = new List<Transform>();


    void Start() {
//        tappedPoints = new List<Transform>();
    }


    void Update() {
        if (!AppUtil.Touched()) {
            return;
        }

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

        tappedPoints.Add(cursorObject.transform);
        Debug.Log(tappedPoints.Count);
        if (tappedPoints.Count >= 2) {
            var point1 = tappedPoints[0].position;
            var point2 = tappedPoints[1].position;
            var point3 = new Vector3(point1.x, point1.y + 100, point1.z);

            Debug.Log(point1);
            Debug.Log(point2);
            Debug.Log(point3);

            var mesh = new Mesh {
                vertices = new Vector3[] {
                    point1,
                    point2,
                    point3
                },
                triangles = new int[] {0, 1, 2}
            };

            mesh.RecalculateNormals();
            var filter = GetComponent<MeshFilter>();
            filter.sharedMesh = mesh;
        }
    }
}