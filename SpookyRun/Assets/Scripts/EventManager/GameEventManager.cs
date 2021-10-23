using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEventManager : MonoBehaviour
{
    private void checkForPause()
    {
        if (Input.GetKeyUp(KeyCode.P)) {
            SceneManager.LoadScene("Settings");
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkForPause();
    }
}
