using Lean.Gui;
using UnityEngine;
using UnityEngine.UI;
using SpaceShooter.Architecture;
using System;

namespace SpaceShooter
{
    public class UIUpgradeMenu : MonoBehaviour
    {
        #region Fields;

        [Header("KINEMATIC")]
        [SerializeField] private LeanToggle kinematicToggle;
        [SerializeField] private Slider kinematicBar;
        [SerializeField] private LeanButton kinematicUpgradeButton;

        [Header("BLASTER")]
        [SerializeField] private LeanToggle blasterToggle;
        [SerializeField] private Slider blasterBar;
        [SerializeField] private LeanButton blasterUpgradeButton;

        [Header("LASER")]
        [SerializeField] private LeanToggle laserToggle;
        [SerializeField] private Slider laserBar;
        [SerializeField] private LeanButton laserUpgradeButton;

        [Header("HEALTH")]
        [SerializeField] private Slider healthBar;
        [SerializeField] private LeanButton healthUpgradeButton;

        [Header("SHIELD")]
        [SerializeField] private Slider shieldBar;
        [SerializeField] private LeanButton shieldUpgradeButton;

        [Header("ENGINE")]
        [SerializeField] private Slider engineBar;
        [SerializeField] private LeanButton engineUpgradeButton;

        [Header("OTHER BUTTONS")]
        [SerializeField] private LeanButton playButton;
        [SerializeField] private LeanButton appearenceButton;
        [SerializeField] private LeanButton menuButton;

        [Header("Canvases")]
        [SerializeField] private Canvas mainMenu;
        [SerializeField] private Canvas upgradeMenu;
        [SerializeField] private Canvas cosmeticMenu;

        private PlayerStatsInteractor playerStats;
        private WeaponsInteractor weaponsInteractor;


        #endregion

        private void OnGameInitialized()
        {
            playerStats = Game.GetInteractor<PlayerStatsInteractor>();
            weaponsInteractor = Game.GetInteractor<WeaponsInteractor>();

            healthBar.value = playerStats.HealthLevel;
            shieldBar.value = playerStats.ShieldLevel;
            engineBar.value = playerStats.SpeedLevel;

            
        }

        private void OnEnable()
        {
            Game.GameInitializedEvent += OnGameInitialized;
            
            kinematicToggle.OnOn.AddListener(OnKinematicSelected);
            blasterToggle.OnOn.AddListener(OnBlasterSelected);
            laserToggle.OnOn.AddListener(OnLaserSelected);
            
            kinematicUpgradeButton.OnClick.AddListener(OnKinematicUpgradeClicked);
            blasterUpgradeButton.OnClick.AddListener(OnBlasterUpgradeClicked);
            laserUpgradeButton.OnClick.AddListener(OnLaserUpgradeClicked);

            healthUpgradeButton.OnClick.AddListener(OnHealthUpgradeClicked);
            shieldUpgradeButton.OnClick.AddListener(OnShieldUpgradeClicked);
            engineUpgradeButton.OnClick.AddListener(OnEngineUpgradeClicked);

            playButton.OnClick.AddListener(OnPlayButtonClicked);
            appearenceButton.OnClick.AddListener(OnAppearenceButtonClicked);
            menuButton.OnClick.AddListener(OnMenuButtonClicked);
        }


        private void OnDisable()
        {
            Game.GameInitializedEvent -= OnGameInitialized;
            
            kinematicToggle.OnOn.RemoveListener(OnKinematicSelected);
            blasterToggle.OnOn.RemoveListener(OnBlasterSelected);
            laserToggle.OnOn.RemoveListener(OnLaserSelected);
            
            kinematicUpgradeButton.OnClick.RemoveListener(OnKinematicUpgradeClicked);
            blasterUpgradeButton.OnClick.RemoveListener(OnBlasterUpgradeClicked);
            laserUpgradeButton.OnClick.RemoveListener(OnLaserUpgradeClicked);

            healthUpgradeButton.OnClick.RemoveListener(OnHealthUpgradeClicked);
            shieldUpgradeButton.OnClick.RemoveListener(OnShieldUpgradeClicked);
            engineUpgradeButton.OnClick.RemoveListener(OnEngineUpgradeClicked);

            playButton.OnClick.RemoveListener(OnPlayButtonClicked);
            appearenceButton.OnClick.RemoveListener(OnAppearenceButtonClicked);
            menuButton.OnClick.RemoveListener(OnMenuButtonClicked);
        }

        private void OnKinematicSelected()
        {
            weaponsInteractor.SelectKinematic();
        }

        private void OnBlasterSelected()
        {
            weaponsInteractor.SelectBlaster();
        }

        private void OnLaserSelected()
        {
            weaponsInteractor.SelectLaser();
        }

        private void OnKinematicUpgradeClicked()
        {
            
        }

        private void OnBlasterUpgradeClicked()
        {

        }

        private void OnLaserUpgradeClicked()
        {

        }

        private void OnHealthUpgradeClicked()
        {
            playerStats.UpgradeMaxHealth();
            healthBar.value = playerStats.HealthLevel;
        }

        private void OnShieldUpgradeClicked()
        {
            playerStats.UpgradeMaxShield();
            shieldBar.value = playerStats.ShieldLevel;
        }

        private void OnEngineUpgradeClicked()
        {
            playerStats.UpgradeMaxSpeed();
            engineBar.value = playerStats.SpeedLevel;
        }

        private void OnPlayButtonClicked()
        {
            Game.SceneManager.LoadNewSceneAsync(SceneConfigGame.SCENE_NAME);
        }

        private void OnMenuButtonClicked()
        {
            mainMenu.gameObject.SetActive(true);
            upgradeMenu.gameObject.SetActive(false);
            cosmeticMenu.gameObject.SetActive(false);
        }

        private void OnAppearenceButtonClicked()
        {
            mainMenu.gameObject.SetActive(false);
            upgradeMenu.gameObject.SetActive(false);
            cosmeticMenu.gameObject.SetActive(true);
        }
    }
}