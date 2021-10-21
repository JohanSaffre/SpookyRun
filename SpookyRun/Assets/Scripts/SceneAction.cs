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
	public Animator animator;

    public void LaunchGameCinematic()
    {
        animator.SetTrigger("playCinematic");
    }

    public void LoadPage(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}