using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooter : MonoBehaviour {
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject racketPrefab;

    private GameObject ball;
    private GameObject racket;

    private void FixedUpdate() {
        if (!GameManager.RoomGenerated) {
            return;
        }

        if (!AppUtil.Touched()) {
            return;
        }

        if (!racket) {
            racket = Instantiate(racketPrefab, transform);
            racket.transform.localPosition = new Vector3(0, 0, 0.1f);
        }


        ball = Instantiate(ballPrefab);
        ball.transform.position = transform.position + transform.forward * 0.15f;
        var speed = 3.0f;
        var vec = transform.forward * speed;
        ball.GetComponent<Rigidbody>().velocity = vec;
    }
}