//using UnityEngine;
//using System.Collections;
//
//[RequireComponent(typeof(MeshRenderer))]
//[RequireComponent(typeof(MeshFilter))]
//public class DynamicCreateMesh : MonoBehaviour {
//    private void Start() {
//        Debug.Log("Start");
//        var mesh = new Mesh();
//        mesh.vertices = new Vector3[] {
//            new Vector3(0, 100f),
//            new Vector3(100f, -100f),
//            new Vector3(-100f, -100f),
//        };
//        mesh.triangles = new int[] {
//            0, 1, 2
//        };
//        mesh.RecalculateNormals();
//        var filter = GetComponent<MeshFilter>();
//        filter.sharedMesh = mesh;
//    }
//}

