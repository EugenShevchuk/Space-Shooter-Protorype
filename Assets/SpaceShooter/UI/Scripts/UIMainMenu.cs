using UnityEngine;
using SpaceShooter.Architecture;
using Lean.Gui;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private Canvas mainMenu;
    [SerializeField] private Canvas upgradeMenu;
    [SerializeField] private Canvas cosmeticMenu;
    [SerializeField] private LeanButton playButton;
    [SerializeField] private LeanButton toHangarButton;
    [SerializeField] private LeanButton exitButton;

    private void Awake()
    {
        if (upgradeMenu != null && cosmeticMenu != null && upgradeMenu != null)
        {
            mainMenu.gameObject.SetActive(true);
            upgradeMenu.gameObject.SetActive(false);
            cosmeticMenu.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        playButton.OnClick.AddListener(OnPlayButtonClicked);
        toHangarButton.OnClick.AddListener(OnToHangarButtonClicked);
        exitButton.OnClick.AddListener(OnExitButtonClicked);
    }

    private void OnDisable()
    {
        playButton.OnClick.RemoveListener(OnPlayButtonClicked);
        toHangarButton.OnClick.RemoveListener(OnToHangarButtonClicked);
        exitButton.OnClick.RemoveListener(OnExitButtonClicked);
    }

    public void OnPlayButtonClicked()
    {
        Game.SceneManager.LoadNewSceneAsync(SceneConfigGame.SCENE_NAME);
    }

    public void OnToHangarButtonClicked()
    {
        mainMenu.gameObject.SetActive(false);
        upgradeMenu.gameObject.SetActive(true);
        cosmeticMenu.gameObject.SetActive(false);
    }

    public void OnExitButtonClicked()
    {
        Application.Quit();
    }
}
