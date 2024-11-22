using Models;
using TMPro;
using UnityEngine;

namespace Controllers
{
    public class ResourcesViewer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinsText;
        [SerializeField] private Wallet _wallet;
        
        private void Start()
        {
            _wallet.BalanceChanged += ViewCoins;
        }

        private void ViewCoins()
        {
            _coinsText.text = _wallet.Coins.ToString();
        }
    }
}
