using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterInventory : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    public AudioManager audioManager;
    public Animator portraitAnimation;

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
        boxCount += 1;
        boxCountLabel.text = ": " + boxCount;
        // PLAY SOUNDS
        audioManager.Play("CollectBox");
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Box") {
            UpdateBoxCount();
        } else if (collision.gameObject.tag == "DeathDrop") {
            UpdateDeathCount();
            rigidBody2D.position = new Vector2(-4, 7);
        }
    }
}
