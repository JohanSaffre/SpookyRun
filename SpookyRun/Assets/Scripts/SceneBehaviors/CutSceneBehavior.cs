using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneBehavior : MonoBehaviour
{
    public string sceneToLoad;
    public SceneAction sceneAction;

    private void checkForPause()
    {
        if (Input.GetKeyUp(KeyCode.Return))
            sceneAction.FadeOut(sceneToLoad);
    }

    // Update is called once per frame
    void Update()
    {
        checkForPause();
    }
}
