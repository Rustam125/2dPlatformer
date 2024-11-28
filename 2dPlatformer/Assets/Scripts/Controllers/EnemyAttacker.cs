using Helpers;
using Interfaces;
using Models;
using UnityEngine;

namespace Controllers
{
    [RequireComponent(typeof(AnimatedCharacter))]
    public class EnemyAttacker : MonoBehaviour
    {
        private const float MinDistanceToAttack = 1f;

        [SerializeField] private float _forceDamage = 1f;
        [SerializeField] private float _delay = 2f;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private AudioSource _audioSource;

        private CharacterHelper _characterHelper;
        private AnimatedCharacter _animatedCharacter;
        private IDamageable _damageableTarget;
        private float _attackCooldown;
        private bool _isAttacking;
        private bool _isCooling;

        private void Awake()
        {
            _animatedCharacter = GetComponent<AnimatedCharacter>();
            _attackCooldown = _delay;
            _characterHelper = new CharacterHelper();
        }

        private void Start()
        {
            _attackCooldown = _delay;
        }

        private void FixedUpdate()
        {
            AttackHandle();
        }

        public void TriggerCooling()
        {
            _isCooling = true;
        }

        private void AttackHandle()
        {
            if (_characterHelper.IsSeeGameObject(transform, MinDistanceToAttack, _layerMask, out _damageableTarget) == false ||
                _damageableTarget is not Player)
            {
                StopAttack();
                return;
            }

            if (_isCooling)
            {
                Cooldown();
                _animatedCharacter.IsHitting = false;
            }
            else
            {
                Attack();
            }
        }

        private void Cooldown()
        {
            _attackCooldown -= Time.deltaTime;

            if (_attackCooldown <= 0 == false || !_isCooling || !_isAttacking)
            {
                return;
            }

            _isCooling = false;
            _attackCooldown = _delay;
        }

        private void Attack()
        {
            _attackCooldown = _delay;
            _isAttacking = _animatedCharacter.IsHitting = true;
            _audioSource.Play();
            _damageableTarget?.TakeDamage(_forceDamage);
            TriggerCooling();
        }

        private void StopAttack()
        {
            _isCooling = _isAttacking = _animatedCharacter.IsHitting = false;
        }
    }
}