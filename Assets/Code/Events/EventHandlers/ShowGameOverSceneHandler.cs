using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowGameOverSceneHandler : MonoBehaviour
{
    public string gameOverSceneName;

    public void ActivateScene()
    {
        Debug.Log("Activated GameOverScene");
        SceneManager.LoadScene(gameOverSceneName);
    }
}
