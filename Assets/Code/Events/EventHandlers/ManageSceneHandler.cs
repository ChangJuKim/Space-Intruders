using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageSceneHandler : MonoBehaviour
{
    [SerializeField] private StringVariable managerSceneName;
    [SerializeField] private StringVariable mainMenuSceneName;

    void Start()
    {
        LoadSceneAndSetActive(mainMenuSceneName);
    }

    public void UnloadScenesExceptManager()
    {
        for (int i = SceneManager.sceneCount - 1; i >= 0; i--)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name != managerSceneName.Value)
            {
                SceneManager.UnloadSceneAsync(scene);
            }
        }
    }

    public void SetActiveScene(StringVariable sceneName)
    {
        Scene scene = SceneManager.GetSceneByName(sceneName.Value);
        SceneManager.SetActiveScene(scene);
    }

    public void UnloadSingleScene(StringVariable sceneName)
    {
        Scene scene = SceneManager.GetSceneByName(sceneName.name);
        SceneManager.UnloadSceneAsync(scene);
    }

    public void LoadSceneAndSetActive(StringVariable sceneName)
    {
        string name = sceneName.Value;

        if (!isSceneLoaded(name))
        {
            StartCoroutine(LoadSceneAndSetActiveHelper(name));
        }
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

    private bool isSceneLoaded(string sceneName)
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name == sceneName && scene.isLoaded)
            {
                return true;
            }
        }
        return false;
    }

}
