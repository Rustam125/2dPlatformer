using Interfaces;
using UnityEngine;

namespace Models
{
    [RequireComponent(typeof(AnimatedCharacter))]
    public class Enemy : MonoBehaviour, IDamageable
    {
        private const float MinHealth = 0;
        
        private float _health = 20;
        private AnimatedCharacter _animatedCharacter;

        public bool IsPatrolling { get; set; } = true;

        private void Awake()
        {
            _animatedCharacter = GetComponent<AnimatedCharacter>();
        }
        
        public void TakeDamage(float amount)
        {
            _animatedCharacter.IsTakingDamage = true;
            _health -= amount;
            
            if (_health <= MinHealth)
            {
                Destroy(gameObject);
            }
        }
    }
}
