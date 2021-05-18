using UnityEngine;
using UnityEngine.SceneManagement;

public class UISceneLoader : MonoBehaviour
{
    private const string UI_SCENE_NAME = "InGameUI";

    private void Awake()
    {
        if (SceneManager.GetSceneByName(UI_SCENE_NAME).isLoaded == false)
            SceneManager.LoadSceneAsync(UI_SCENE_NAME, LoadSceneMode.Additive);
    }

}
