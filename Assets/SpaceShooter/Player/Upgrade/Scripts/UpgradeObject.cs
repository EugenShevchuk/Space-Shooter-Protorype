using UnityEngine;

namespace SpaceShooter
{
    [CreateAssetMenu(fileName = "UpgradeCost", menuName = "ScriptableObjects/UpgradeCost")]
    public class UpgradeObject : ScriptableObject
    {
        [Header("If can purchase")]
        public Color CanPurchaseMainColor;
        public Color CanPurchaseTransitionColor;

        [Header("If can not purchase")]
        public Color CanNotPurchaseMainColor;
        public Color CanNotPurchaseTransitionColor;

        [Header("Costs")]
        public int costLevelOne;
        public int costLevelTwo;
        public int costLevelThree;
        public int costLevelFour;
        public int costLevelFive;
        public int costLevelSix;
        public int costLevelSeven;
        public int costLevelEight;
        public int costLevelNine;
        public int costLevelTen;
    }
}
