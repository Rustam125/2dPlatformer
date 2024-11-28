using Helpers;
using Interfaces;
using Models;
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
        [SerializeField] private InputReader _input;

        private CharacterHelper _characterHelper;
        private AnimatedCharacter _animatedCharacter;
        
        private void Awake()
        {
            _animatedCharacter = GetComponent<AnimatedCharacter>();
            _characterHelper = new CharacterHelper();
        }

        private void OnEnable()
        {
            _input.Attacked += Attack;
            _input.AttackCompleted += CompleteAttack;
        }

        private void OnDisable()
        {
            _input.Attacked -= Attack;
            _input.AttackCompleted -= CompleteAttack;
        }

        private void Attack()
        {
            _animatedCharacter.IsHitting = true;
            _audioSource.Play();

            if (_characterHelper.IsSeeGameObject(transform, MinDistanceToAttack, _layerMask, out IDamageable damageableTarget) &&
                damageableTarget is not Player)
            {
                damageableTarget?.TakeDamage(_forceDamage);
            }
        }

        private void CompleteAttack()
        {
            _animatedCharacter.IsHitting = false;
        }
    }
}
