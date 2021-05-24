using Lean.Gui;
using UnityEngine;
using UnityEngine.UI;
using SpaceShooter.Architecture;

namespace SpaceShooter
{
    public class UIUpgradeMenu : MonoBehaviour
    {
        #region Fields

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

        private PlayerStatsInteractor playerStatsInteractor;
        private WeaponsInteractor weaponsInteractor;
        private KinematicWeaponInteractor kinematicInteractor;
        private BlasterWeaponInteractor blasterInteractor;
        private LaserWeaponInteractor laserInteractor;

        #endregion

        #region OnEnable/OnDisable
        private void OnEnable()
        {
            playerStatsInteractor = Game.GetInteractor<PlayerStatsInteractor>();
            weaponsInteractor = Game.GetInteractor<WeaponsInteractor>();
            kinematicInteractor = Game.GetInteractor<KinematicWeaponInteractor>();
            blasterInteractor = Game.GetInteractor<BlasterWeaponInteractor>();
            laserInteractor = Game.GetInteractor<LaserWeaponInteractor>();
                       
            kinematicToggle.OnOn.AddListener(OnKinematicSelected);
            blasterToggle.OnOn.AddListener(OnBlasterSelected);
            laserToggle.OnOn.AddListener(OnLaserSelected);
            SetToggles();

            kinematicUpgradeButton.OnClick.AddListener(OnKinematicUpgradeClicked);
            blasterUpgradeButton.OnClick.AddListener(OnBlasterUpgradeClicked);
            laserUpgradeButton.OnClick.AddListener(OnLaserUpgradeClicked);

            healthUpgradeButton.OnClick.AddListener(OnHealthUpgradeClicked);
            shieldUpgradeButton.OnClick.AddListener(OnShieldUpgradeClicked);
            engineUpgradeButton.OnClick.AddListener(OnEngineUpgradeClicked);

            playButton.OnClick.AddListener(OnPlayButtonClicked);
            appearenceButton.OnClick.AddListener(OnAppearenceButtonClicked);
            menuButton.OnClick.AddListener(OnMenuButtonClicked);

            SetSliderValues();
        }

        private void OnDisable()
        {
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
        #endregion

        #region Toggles

        private void SetToggles()
        {
            switch (weaponsInteractor.CurrentWeapon.WeaponType)
            {
                case WeaponType.Kinematic:
                    kinematicToggle.TurnOn();
                    blasterToggle.TurnOff();
                    laserToggle.TurnOff();
                    break;
                case WeaponType.Blaster:
                    kinematicToggle.TurnOff();
                    blasterToggle.TurnOn();
                    laserToggle.TurnOff();
                    break;
                case WeaponType.Laser:
                    kinematicToggle.TurnOff();
                    blasterToggle.TurnOff();
                    laserToggle.TurnOn();
                    break;
                default:
                    kinematicToggle.TurnOn();
                    blasterToggle.TurnOff();
                    laserToggle.TurnOff();
                    break;
            }
        }

        private void OnKinematicSelected()
        {
            weaponsInteractor.SelectWeapon(kinematicInteractor);
        }

        private void OnBlasterSelected()
        {
            weaponsInteractor.SelectWeapon(blasterInteractor);
        }

        private void OnLaserSelected()
        {
            weaponsInteractor.SelectWeapon(laserInteractor);
        }

        #endregion

        #region Upgrades;

        private void SetSliderValues()
        {
            healthBar.value = playerStatsInteractor.HealthLevel;
            shieldBar.value = playerStatsInteractor.ShieldLevel;
            engineBar.value = playerStatsInteractor.SpeedLevel;

            kinematicBar.value = kinematicInteractor.Level;
            blasterBar.value = blasterInteractor.Level;
            laserBar.value = laserInteractor.Level;
        }

        private void OnKinematicUpgradeClicked()
        {
            kinematicInteractor.Upgrade();
            SetSliderValues();
        }

        private void OnBlasterUpgradeClicked()
        {
            blasterInteractor.Upgrade();
            SetSliderValues();
        }

        private void OnLaserUpgradeClicked()
        {
            laserInteractor.Upgrade();
            SetSliderValues();
        }

        private void OnHealthUpgradeClicked()
        {
            playerStatsInteractor.UpgradeMaxHealth();
            SetSliderValues();
        }

        private void OnShieldUpgradeClicked()
        {
            playerStatsInteractor.UpgradeMaxShield();
            SetSliderValues();
        }

        private void OnEngineUpgradeClicked()
        {
            playerStatsInteractor.UpgradeMaxSpeed();
            SetSliderValues();
        }
        #endregion

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