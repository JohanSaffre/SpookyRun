using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatforms : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "Ground" && collision.collider.name != "Ground") {
            collision.collider.GetComponent<Animator>().SetTrigger("Fall");
        }
    }
}
