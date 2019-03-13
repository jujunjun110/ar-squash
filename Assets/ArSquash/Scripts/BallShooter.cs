using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooter : MonoBehaviour {
    [SerializeField] private GameObject ballPrefab;
    private GameObject ball;

    private void FixedUpdate() {
        if (!Input.GetKeyUp(KeyCode.Space)) {
            return;
        }

        Debug.Log("Space Pushed");

//        if (ball) {
//            return;
//        }

        ball = Instantiate(ballPrefab);
        ball.transform.position = transform.position;
        var speed = 10.0f;
        var vec = this.transform.forward * speed;
        ball.GetComponent<Rigidbody>().velocity = vec;
    }
}