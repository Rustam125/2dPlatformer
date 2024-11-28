using Models;
using TMPro;
using UnityEngine;

namespace Controllers
{
    public class ResourcesViewer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinsText;
        [SerializeField] private TextMeshProUGUI _healthPointsText;
        [SerializeField] private Wallet _wallet;
        [SerializeField] private Player _player;
        
        private void Start()
        {
            _wallet.BalanceChanged += ViewCoins;
            _player.HealthChanged += ViewHp;
            Init();
        }

        private void Init()
        {
            ViewCoins();
            ViewHp();
        }

        private void ViewCoins()
        {
            _coinsText.text = _wallet.Coins.ToString();
        }
        
        private void ViewHp()
        {
            _healthPointsText.text = $"HP {_player.Health}";
        }
    }
}
