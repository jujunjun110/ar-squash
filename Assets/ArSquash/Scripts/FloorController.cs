using UnityEngine;

public class FloorController : MonoBehaviour {
    public int scale = 1;
    public int max_scale = 100;

    void Start() {
        scale = 1;
    }

    void Update() {
        if (scale > max_scale) {
            return;
        }

        scale++;
        transform.localScale = new Vector3(scale, 0.01f, scale);
    }
}