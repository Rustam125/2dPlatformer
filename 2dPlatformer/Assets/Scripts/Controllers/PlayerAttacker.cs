using Helpers;
using Interfaces;
using Models;
using Unity.VisualScripting;
using UnityEngine;

namespace Controllers
{
    [RequireComponent(typeof(AnimatedCharacter))]
    public class PlayerAttacker : MonoBehaviour
    {
        private const float MinDistanceToAttack = 1f;
        
        [SerializeField] private float _forceDamage = 2f;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private AudioSource _audioSource;

        private AnimatedCharacter _animatedCharacter;
        
        private void Awake()
        {
            _animatedCharacter = GetComponent<AnimatedCharacter>();
        }

        private void Update()
        {
            Attack();
        }

        private void Attack()
        {
            if (Input.GetMouseButtonDown((int)MouseButton.Left) == false)
            {
                _animatedCharacter.IsHitting = false;
                return;
            }
            
            _animatedCharacter.IsHitting = true;
            _audioSource.Play();

            if (MainHelper.IsSeeGameObject(transform, MinDistanceToAttack, _layerMask, out IDamageable damageableTarget) &&
                damageableTarget is not Player)
            {
                damageableTarget?.TakeDamage(_forceDamage);
            }
        }
    }
}
