using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public enum Scenes
    {
        MainMenu,
        LoadingScreen,
        Hangar,
        GameScene
    }

    private static Action onLoaderCallback;

    public static void Load(Scenes scene)
    {
        onLoaderCallback = () =>
        {
            SceneManager.LoadScene(scene.ToString());
        };

        SceneManager.LoadScene(Scenes.LoadingScreen.ToString());
    }

    public static void LoaderCallback()
    {
        if (onLoaderCallback != null)
        {
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }
}
