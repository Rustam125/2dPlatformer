using Models;
using UnityEngine;

namespace Controllers
{
    public class KitCollector : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Player _player;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out Kit kit) == false)
            {
                return;
            }

            _audioSource.Play();
            _player.Heal(kit.HealPoints);
            Destroy(kit.gameObject);
        }
    }
}