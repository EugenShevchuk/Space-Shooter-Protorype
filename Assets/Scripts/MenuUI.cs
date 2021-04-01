using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public void PlayClicked()
    {
        SceneLoader.Load(SceneLoader.Scenes.GameScene);
    }

    public void ToHangarClicked()
    {
        SceneLoader.Load(SceneLoader.Scenes.Hangar);
    }

    public void MenuClicked()
    {
        SceneLoader.Load(SceneLoader.Scenes.MainMenu);
    }

    public void ExitClicked()
    {
        Application.Quit();
    }
}
