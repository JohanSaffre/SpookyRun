/*
File: MenuAction.cs

Author: Corentin ROZET
Email: corentin.rozet@epitech.eu
Creation date: 2021, October 04

Copyright 2021, Corentin ROZET, Johan SAFFRE
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAction : MonoBehaviour
{
	public Animator fader;

    public void FadeOut(string sceneName)
    {
        PlayerPrefs.SetString("sceneToLoad", sceneName);
        fader.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        if (PlayerPrefs.GetString("sceneToLoad") == "Game") {
            FindObjectOfType<AudioManager>().StopAllMusic();
            FindObjectOfType<AudioManager>().Play("ThemeGame");
        }
        SceneManager.LoadScene(PlayerPrefs.GetString("sceneToLoad"));
    }

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame() {
        Application.Quit();
    }
}