using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageSceneHandler : MonoBehaviour
{
    [SerializeField] private StringVariable managerSceneName;

    public void UnloadScenesExceptManager()
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name != managerSceneName.Value)
            {
                AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(scene);
            }
        }
    }

    public void LoadSceneAndSetActive(StringVariable sceneName)
    {
        StartCoroutine(LoadSceneAndSetActiveHelper(sceneName.Value));
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
