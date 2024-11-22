using Models;
using UnityEngine;

namespace Controllers
{
    public class CoinCollector : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Wallet _wallet;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out Coin coin) == false)
            {
                return;
            }
            
            Destroy(coin.gameObject);
            _audioSource.Play();
            _wallet.AddCoin();
        }
    }
}