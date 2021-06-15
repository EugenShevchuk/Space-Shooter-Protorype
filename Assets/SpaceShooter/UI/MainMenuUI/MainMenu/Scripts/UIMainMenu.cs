using UnityEngine;
using SpaceShooter.Architecture;
using Lean.Gui;

namespace SpaceShooter
{
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
            if (this.upgradeMenu != null && this.cosmeticMenu != null && this.upgradeMenu != null)
            {
                this.mainMenu.gameObject.SetActive(true);
                this.upgradeMenu.gameObject.SetActive(false);
                this.cosmeticMenu.gameObject.SetActive(false);
            }
        }

        private void OnEnable()
        {
            this.playButton.OnClick.AddListener(OnPlayButtonClicked);
            this.toHangarButton.OnClick.AddListener(OnToHangarButtonClicked);
            this.exitButton.OnClick.AddListener(OnExitButtonClicked);
        }

        private void OnDisable()
        {
            this.playButton.OnClick.RemoveListener(OnPlayButtonClicked);
            this.toHangarButton.OnClick.RemoveListener(OnToHangarButtonClicked);
            this.exitButton.OnClick.RemoveListener(OnExitButtonClicked);
        }

        public void OnPlayButtonClicked()
        {
            Game.SceneManager.LoadNewSceneAsync(SceneConfigGame.SCENE_NAME);
        }

        public void OnToHangarButtonClicked()
        {
            this.mainMenu.gameObject.SetActive(false);
            this.upgradeMenu.gameObject.SetActive(true);
            this.cosmeticMenu.gameObject.SetActive(false);
        }

        public void OnExitButtonClicked()
        {
            Application.Quit();
        }
    }
}