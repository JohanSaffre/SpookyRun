/*
File: CharacterMove.cs

Author: Corentin ROZET
Email: corentin.rozet@epitech.eu
Creation date: 2021, October 04

Copyright 2021, Corentin ROZET, Johan SAFFRE
*/

using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour
{
	public SceneAction sceneAction;
	private Rigidbody2D rigidBody2D;
	public Animator animator;

	// MOVEMENT PARAMS
	public float speed = 15;
	public float jumpForce = 45;

	// POSITION PARAMS
	public static Vector2 pos = new Vector2(-4, 7);
	private static float direction = 1; // 1 for RIGHT -1 for LEFT

	private static int level = 1;
	private bool finishLevel = false;

	public int getLevel() {return (level);}

	void Awake()
	{
		finishLevel = false;
		rigidBody2D = GetComponent<Rigidbody2D>();
		gameObject.transform.position = new Vector3(pos.x, pos.y, 0);
	}

	void Start()
	{
		if (direction == -1)
			Flip(1, false); // Realign Sprite to direction
	}

	void Update()
	{
		// CHECK FOR HORIZONTAL MOVEMENT
		Walk();
		// CHECK FOR JUMP TRIGGERING
		if (Input.GetKeyDown(KeyCode.Space) && animator.GetBool("isJumping") == false)
            Jump();
		// CHECK FOR CROUCH TRIGGERING
		if (Input.GetKey(KeyCode.E) && animator.GetBool("isJumping") == false)
			Crouch(true);
		else
			Crouch(false);
	}

	void Walk()
	{
		float xMove = Input.GetAxis("Horizontal") * speed;

		rigidBody2D.velocity = new Vector2(xMove, rigidBody2D.velocity.y);
		if (xMove != 0)
			Flip(xMove, true); // CHANGE DIRECTION
		// SET SPEED FOR ANIMATOR
		animator.SetFloat("Speed", Mathf.Abs(xMove));
	}

	void Crouch(bool isCrouching)
	{
		animator.SetBool("isCrouching", isCrouching);
	}

	void Jump()
	{
		rigidBody2D.velocity = Vector2.up * jumpForce;
		animator.SetBool("isJumping", true);
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Finish") {
			finishLevel = true;
			// Change Scene
			string nextScene;
			if (level == 3)
				nextScene = "GameOverWin";
			else
				nextScene = "CutScene"+level;
			level += 1;
			sceneAction.FadeOut(nextScene);
		}
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
			animator.SetBool("isJumping", false);
    }

	void Flip(float newDirection, bool update)
	{
		// Normalize direction to [-1, 1]
		newDirection = newDirection / Mathf.Abs(newDirection);

		if (newDirection != direction) {
			if (update) // CHANGE DIRECTION
				direction = newDirection;
			// Multiply the player's x local scale by -1.
			Vector3 scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;
			// Flip Child (Camera) so it stay in the same direction
			Vector3 scaleCamera = transform.GetChild(0).transform.localScale;
			scaleCamera.x *= -1;
			transform.GetChild(0).transform.localScale = scaleCamera;
		}
	}

	void OnDestroy()
	{
		// Save Character's Pos
		pos = gameObject.transform.position;
		if (finishLevel)
			pos =  new Vector2(-4, 7); // RE-INIT CHARACTER POS
	}
}
