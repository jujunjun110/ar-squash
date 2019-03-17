using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {
    private int hitCount;

    private void OnCollisionExit(Collision col) {
        switch (col.gameObject.tag) {
            case "SquashField":
                hitCount++;
                Debug.Log(hitCount);
                SpeedUp(1.05f);
                break;
            case "Racket":
                hitCount = 0;
                break;
        }
    }

    private void SpeedUp(float rate) {
        GetComponent<Rigidbody>().velocity *= rate;
    }
}