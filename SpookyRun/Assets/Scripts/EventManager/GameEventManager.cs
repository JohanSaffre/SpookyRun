using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEventManager : MonoBehaviour
{
    public CharacterMove character;

    private void checkForPause()
    {
        if (Input.GetKeyUp(KeyCode.P)) {
            PlayerPrefs.SetString("SettingBackButton", "Level"+character.getLevel());
            SceneManager.LoadScene("Settings");
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkForPause();
    }
}
