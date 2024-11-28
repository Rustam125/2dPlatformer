using System;
using Interfaces;
using UnityEngine;

namespace Models
{
    [RequireComponent(typeof(AnimatedCharacter))]
    public class Player : MonoBehaviour, IDamageable, IHealable
    {
        private const float MinHealth = 0;
        
        private AnimatedCharacter _animatedCharacter;

        public float Health { get; private set; } = 100;
        public event Action HealthChanged;

        private void Awake()
        {
            _animatedCharacter = GetComponent<AnimatedCharacter>();
        }
        
        public void TakeDamage(float amount)
        {
            _animatedCharacter.IsTakingDamage = true;
            Health -= amount;
            HealthChanged?.Invoke();
            
            if (Health <= MinHealth)
            {
                Destroy(gameObject);
            }
        }

        public void Heal(float amount)
        {
            Health += amount;
            HealthChanged?.Invoke();
        }
    }
}
