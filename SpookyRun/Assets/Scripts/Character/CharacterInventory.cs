using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterInventory : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    public Animator portraitAnimation;
    public Animator animator;

    public Text boxCountLabel;
    public Text deathCountLabel;

    static int boxCount = 0;
    static int deathCount = 0;

	void Awake()
	{
		rigidBody2D = GetComponent<Rigidbody2D>();
	}

    // Start is called before the first frame update
    void Start()
    {
        boxCountLabel.text = ": " + boxCount;
        deathCountLabel.text = ": " + deathCount;
    }

    void UpdateBoxCount()
    {
        // PLAY SOUNDS
        FindObjectOfType<AudioManager>().Play("CollectBox");
        // UPDATE LABEL
        boxCount += 1;
        boxCountLabel.text = ": " + boxCount;
    }

    void UpdateDeathCount()
    {
        deathCount += 1;
        deathCountLabel.text = ": " + deathCount;
        // TRIGGER ANIMATION
        portraitAnimation.SetBool("isDamaged", true);
    }

    void ResetDamage()
    {
        portraitAnimation.SetBool("isDamaged", false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Box") {
            UpdateBoxCount();
            Destroy(collision.gameObject);
        }
    }

    public void ReInitPos()
    {
        rigidBody2D.position = new Vector2(-4, 7);
        animator.SetBool("isDying", false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeathDrop" || collision.gameObject.tag == "Zombies") {
            UpdateDeathCount();
            animator.SetBool("isDying", true);
        }
    }
}
