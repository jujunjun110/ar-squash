using System;
using UnityEngine;
using UnityEngine.AI;

public class Blinker : MonoBehaviour {
    private static int count;

    public bool doBlink = true;

    public int loopDuration = 1000;
    public double max_opacity = 0.7;
    public double min_opacity = 0.5;

    void Update() {
        if (!doBlink) {
            return;
        }

        var milliSec = DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
        var percentage = (milliSec % loopDuration) / (float) loopDuration;
        var meshRenderer = GetComponent<MeshRenderer>();
        var opacity_range = (max_opacity - min_opacity) / 2;
        var opacity = (float) (Math.Sin(percentage * 2 * Math.PI) * opacity_range + min_opacity + opacity_range);
        var _color = meshRenderer.material.color;
        _color.a = opacity;
        meshRenderer.material.color = _color;
    }
}