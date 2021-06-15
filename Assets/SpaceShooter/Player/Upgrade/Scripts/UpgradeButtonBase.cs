using SpaceShooter.Architecture;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Lean.Transition.Method;

namespace SpaceShooter
{
    public class UpgradeButtonBase : MonoBehaviour
    {
        [SerializeField] private LeanGraphicColor normalTransition;
        [SerializeField] private LeanGraphicColor downTransition;

        [SerializeField] private UpgradeObject upgradeObject;
        [SerializeField] private Image capImage;
        [SerializeField] private Text textCost;
        [SerializeField] private Slider correspondingSlider;
        private bool isUpgradable;

        private BankInteractor bank;

        private Dictionary<int, int> upgradeCostMap;

        protected void Initialize(IUpgradable interactor)
        {
            this.bank = Game.GetInteractor<BankInteractor>();

            this.upgradeCostMap = new Dictionary<int, int>()
            {
                [0] = this.upgradeObject.costLevelOne,
                [1] = this.upgradeObject.costLevelTwo,
                [2] = this.upgradeObject.costLevelThree,
                [3] = this.upgradeObject.costLevelFour,
                [4] = this.upgradeObject.costLevelFive,
                [5] = this.upgradeObject.costLevelSix,
                [6] = this.upgradeObject.costLevelSeven,
                [7] = this.upgradeObject.costLevelEight,
                [8] = this.upgradeObject.costLevelNine,
                [9] = this.upgradeObject.costLevelTen,
            };

            SetUpButton(interactor.Level);
        }

        protected void Upgrade(IUpgradable interactor)
        {
            if (this.isUpgradable)
            {
                this.bank.SpendMoney(this.upgradeCostMap[interactor.Level]);
                interactor.Upgrade();
                this.SetUpButton(interactor.Level);
            }
        }
          
        private void SetUpButton(int level)
        {
            if (this.bank.IsEnoughMoney(this.upgradeCostMap[level]))
            {
                this.capImage.color = this.upgradeObject.CanPurchaseMainColor;
                this.normalTransition.Data.Color = this.upgradeObject.CanPurchaseMainColor;
                this.downTransition.Data.Color = this.upgradeObject.CanPurchaseTransitionColor;
                this.isUpgradable = true;
            }
            else
            {
                this.capImage.color = this.upgradeObject.CanNotPurchaseMainColor;
                this.normalTransition.Data.Color = this.upgradeObject.CanNotPurchaseMainColor;
                this.downTransition.Data.Color = this.upgradeObject.CanNotPurchaseTransitionColor;
                this.isUpgradable = false;
            }

            this.correspondingSlider.value = level;
            this.textCost.text = $"{this.upgradeCostMap[level]}";
        }
    }
}