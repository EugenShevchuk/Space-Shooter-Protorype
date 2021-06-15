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

        private WeaponsInteractor weaponsInteractor;
        private KinematicWeaponInteractor kinematicInteractor;
        private BlasterWeaponInteractor blasterInteractor;
        private LaserWeaponInteractor laserInteractor;

        #endregion

        #region OnEnable/OnDisable
        private void OnEnable()
        {
            this.weaponsInteractor = Game.GetInteractor<WeaponsInteractor>();
            this.kinematicInteractor = Game.GetInteractor<KinematicWeaponInteractor>();
            this.blasterInteractor = Game.GetInteractor<BlasterWeaponInteractor>();
            this.laserInteractor = Game.GetInteractor<LaserWeaponInteractor>();

            this.kinematicToggle.OnOn.AddListener(OnKinematicSelected);
            this.blasterToggle.OnOn.AddListener(OnBlasterSelected);
            this.laserToggle.OnOn.AddListener(OnLaserSelected);
            this.SetToggles();

            this.playButton.OnClick.AddListener(OnPlayButtonClicked);
            this.appearenceButton.OnClick.AddListener(OnAppearenceButtonClicked);
            this.menuButton.OnClick.AddListener(OnMenuButtonClicked);
        }

        private void OnDisable()
        {
            this.kinematicToggle.OnOn.RemoveListener(OnKinematicSelected);
            this.blasterToggle.OnOn.RemoveListener(OnBlasterSelected);
            this.laserToggle.OnOn.RemoveListener(OnLaserSelected);

            this.playButton.OnClick.RemoveListener(OnPlayButtonClicked);
            this.appearenceButton.OnClick.RemoveListener(OnAppearenceButtonClicked);
            this.menuButton.OnClick.RemoveListener(OnMenuButtonClicked);
        }
        #endregion

        #region Toggles

        private void SetToggles()
        {
            switch (this.weaponsInteractor.CurrentWeapon.WeaponType)
            {
                case WeaponType.Kinematic:
                    this.kinematicToggle.TurnOn();
                    this.blasterToggle.TurnOff();
                    this.laserToggle.TurnOff();
                    break;
                case WeaponType.Blaster:
                    this.kinematicToggle.TurnOff();
                    this.blasterToggle.TurnOn();
                    this.laserToggle.TurnOff();
                    break;
                case WeaponType.Laser:
                    this.kinematicToggle.TurnOff();
                    this.blasterToggle.TurnOff();
                    this.laserToggle.TurnOn();
                    break;
                default:
                    this.kinematicToggle.TurnOn();
                    this.blasterToggle.TurnOff();
                    this.laserToggle.TurnOff();
                    break;
            }
        }

        private void OnKinematicSelected()
        {
            this.weaponsInteractor.SelectWeapon(this.kinematicInteractor);
        }

        private void OnBlasterSelected()
        {
            this.weaponsInteractor.SelectWeapon(this.blasterInteractor);
        }

        private void OnLaserSelected()
        {
            this.weaponsInteractor.SelectWeapon(this.laserInteractor);
        }

        #endregion

        private void OnPlayButtonClicked()
        {
            Game.SceneManager.LoadNewSceneAsync(SceneConfigGame.SCENE_NAME);
        }

        private void OnMenuButtonClicked()
        {
            this.mainMenu.gameObject.SetActive(true);
            this.upgradeMenu.gameObject.SetActive(false);
            this.cosmeticMenu.gameObject.SetActive(false);
        }

        private void OnAppearenceButtonClicked()
        {
            this.mainMenu.gameObject.SetActive(false);
            this.upgradeMenu.gameObject.SetActive(false);
            this.cosmeticMenu.gameObject.SetActive(true);
        }
    }
}