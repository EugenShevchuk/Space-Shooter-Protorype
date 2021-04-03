using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public Canvas upgradeMenu;
    public Canvas cosmeticMenu;

    private void Awake()
    {
        if (upgradeMenu != null && cosmeticMenu != null)
        {
            upgradeMenu.gameObject.SetActive(true);
            cosmeticMenu.gameObject.SetActive(false);
        }
    }

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

    public void AppearnceClicked()
    {
        upgradeMenu.gameObject.SetActive(false);
        cosmeticMenu.gameObject.SetActive(true);
    }

    public void ApplyClicked()
    {
        cosmeticMenu.gameObject.SetActive(false);
        upgradeMenu.gameObject.SetActive(true);        
    }
}
