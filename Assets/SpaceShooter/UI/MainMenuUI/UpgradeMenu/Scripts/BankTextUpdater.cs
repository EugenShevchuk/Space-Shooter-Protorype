using UnityEngine;
using SpaceShooter.Architecture;
using UnityEngine.UI;

namespace SpaceShooter
{
    public class BankTextUpdater : MonoBehaviour
    {
        [SerializeField] private Text text;

        private BankInteractor bank;

        private void OnEnable()
        {
            bank = Game.GetInteractor<BankInteractor>();
            bank.MoneyAmountChanged += UpdateText;
        }

        private void Start()
        {
            UpdateText();
        }

        private void OnDisable()
        {
            bank.MoneyAmountChanged -= UpdateText;
        }

        private void UpdateText()
        {
            this.text.text = $"${bank.Money}";
        }
    }
}