/*
File: CharacterMove.cs

Author: Corentin ROZET
Email: corentin.rozet@epitech.eu
Creation date: 2021, October 04

Copyright 2021, Corentin ROZET, Johan SAFFRE
*/

using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour {

	private Rigidbody2D rigidBody2D;
	public Animator animator;

	// MOVEMENT PARAMS
	public float speed = 30;
	public float jumpForce = 50;
	private bool isGrounded;
	private float direction = 1; // 1 if right, -1 if left
	
	void Awake()
	{
		rigidBody2D = GetComponent<Rigidbody2D>();
	}

	void walk()
	{
		float xMove = Input.GetAxis("Horizontal") * speed;

		rigidBody2D.velocity = new Vector2(xMove, rigidBody2D.velocity.y);
		if (xMove != 0)
			flip(xMove); // CHANGE DIRECTION
		// SET SPEED FOR ANIMATOR
		animator.SetFloat("Speed", Mathf.Abs(xMove));
	}

	void crounch(bool isCrounching)
	{
		animator.SetBool("isCrounching", isCrounching);
	}

	void jump()
	{
		rigidBody2D.velocity = Vector2.up * jumpForce;
		animator.SetBool("isJumping", true);
		isGrounded = false;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") {
			animator.SetBool("isJumping", false);
		    isGrounded = true;
		}
    }

	void flip(float newDirection)
	{
		// Get player direction (True if right, False if left)
		newDirection = newDirection / Mathf.Abs(newDirection);

		if (newDirection != direction) {
			// Multiply the player's x local scale by -1.
			Vector3 scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;
			// CHANGE DIRECTION
			direction = newDirection;
		}
	}

	void Update()
	{
		// CHECK FOR HORIZONTAL MOVEMENT
		walk();
		// CHECK FOR JUMP TRIGGERING
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            jump();
		// CHECK FOR CROUCH TRIGGERING
		if (Input.GetKey(KeyCode.E) && isGrounded)
			crounch(true);
		else
			crounch(false);
	}
}
