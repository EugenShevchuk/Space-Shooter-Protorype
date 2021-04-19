using UnityEngine;
using UnityEngine.SceneManagement;

public class UISceneLoader : MonoBehaviour
{
    private void Awake()
    {
        if (SceneManager.GetSceneByName("InGameUI").isLoaded == false)
            SceneManager.LoadSceneAsync("InGameUI", LoadSceneMode.Additive);
    }

}
