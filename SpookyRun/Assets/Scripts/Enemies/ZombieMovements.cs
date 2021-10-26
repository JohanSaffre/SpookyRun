using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovements : MonoBehaviour
{
    private BoxCollider2D _box;
    private Transform _transform;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private string direction = "right";
    public float speed = 1;

    void Start()
    {
        _box = GetComponent<BoxCollider2D>();
        _transform = GetComponent<Transform>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _animator.SetTrigger("Walking");
    }

    void Update()
    {
        if (direction == "right") {
            _transform.position += new Vector3(1 * Time.deltaTime * speed, 0, 0);
        }
        if (direction == "left") {
            _transform.position -= new Vector3(1 * Time.deltaTime * speed, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D box) {
        if (box.tag == "ZombiBoxLeft") {
            direction = "right";
            _spriteRenderer.flipX = false;
        }
        if (box.tag == "ZombiBoxRight") {
            direction = "left";
            _spriteRenderer.flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (direction == "right") {
            direction = "left";
            _spriteRenderer.flipX = true;
        }
        if (direction == "left") {
            direction = "right";
            _spriteRenderer.flipX = false;
        }
    }
}
