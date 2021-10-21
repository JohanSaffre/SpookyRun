using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInventory : MonoBehaviour
{
    public Text boxCount;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("boxCount", 0);
        boxCount.text = ": " + PlayerPrefs.GetInt("boxCount");
        PlayerPrefs.SetInt("deathCount", 0);
    }

    void UpdateBoxCount()
    {
        PlayerPrefs.SetInt("boxCount", PlayerPrefs.GetInt("boxCount") + 1);
        boxCount.text = ": " + PlayerPrefs.GetInt("boxCount");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Box") {
            UpdateBoxCount();
        }
    }
}
