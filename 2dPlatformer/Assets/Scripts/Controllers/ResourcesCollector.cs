using Interfaces;
using Models;
using UnityEngine;

namespace Controllers
{
    public class ResourcesCollector : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Wallet _wallet;
        [SerializeField] private Player _player;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out IResource resource) == false)
            {
                return;
            }

            _audioSource.clip = resource.AudioClip;
            _audioSource.Play();
            
            switch (resource)
            {
                case Coin coin:
                    CollectCoins(coin);
                    break;
                case Kit kit:
                    CollectKits(kit);
                    break;
            }
        }

        private void CollectCoins(Coin coin)
        {
            _wallet.AddCoin();
            Destroy(coin.gameObject);
        }
        
        private void CollectKits(Kit kit)
        {
            _player.Heal(kit.HealPoints);
            Destroy(kit.gameObject);
        }
    }
}