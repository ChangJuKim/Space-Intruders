using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


// TODO: Find a better way to do these loads and unloads without creating a million scriptableObjects and functions
public class ManageSceneHandler : MonoBehaviour
{
    public StringVariable managerSceneName;
    public StringVariable playerVictorySceneName;
    public StringVariable playerLoseSceneName;
    public StringVariable gameSceneName;

    public void UnloadScenesExceptManager()
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name != managerSceneName.value)
            {
                AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(scene);
            }
        }
    }

    public void ActivateVictoryScene()
    {
        LoadSceneAndSetActive(playerVictorySceneName.value);
    }

    public void DeactivateVictoryScene()
    {
        SceneManager.UnloadSceneAsync(playerVictorySceneName.value);
    }

    public void ActivateGameOverScene()
    {
        LoadSceneAndSetActive(playerLoseSceneName.value);
    }

    public void DeactivateGameOverScene()
    {
        SceneManager.UnloadSceneAsync(playerLoseSceneName.value);
    }

    public void ActivateGameScene()
    {
        LoadSceneAndSetActive(gameSceneName.value);
    }

    public void DeactivateGameScene()
    {
        SceneManager.UnloadSceneAsync(gameSceneName.value);
    }

    private void LoadSceneAndSetActive(string sceneName)
    {
        StartCoroutine(LoadSceneAndSetActiveHelper(sceneName));
    }

    private IEnumerator LoadSceneAndSetActiveHelper(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        Scene loadedScene = SceneManager.GetSceneByName(sceneName);
        if (loadedScene.IsValid())
        {
            SceneManager.SetActiveScene(loadedScene);
        }
        else
        {
            Debug.Log("Failed to load the scene: " + sceneName);
        }
    }

}
