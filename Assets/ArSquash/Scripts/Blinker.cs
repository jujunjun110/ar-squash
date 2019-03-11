using System;
using UnityEngine;

public class Blinker : MonoBehaviour {
    private static int count;
    public bool doBlink = true;
    public double max_opacity = 0.8;
    public double min_opacity = 0.4;

//    Intのデフォルト値は0だから初期化する必要はない？    
//    void Start() {
//        count = 0;
//    }

    void Update() {
        if (!doBlink) {
            return;
        }

        count += 5;
        if (count > 360) {
            count = 0;
        }

        var meshRenderer = GetComponent<MeshRenderer>();
        var opacity_range = (max_opacity - min_opacity) / 2;
        var opacity = (float) (Math.Sin(count * (Math.PI / 180)) * opacity_range + min_opacity + opacity_range);
        var _color = meshRenderer.material.color;
        _color.a = opacity;
        meshRenderer.material.color = _color;
    }
}