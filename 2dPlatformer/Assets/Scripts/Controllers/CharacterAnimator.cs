using Models;
using UnityEngine;

namespace Controllers
{
    [RequireComponent(typeof(Animator), typeof(AnimatedCharacter))]
    public class CharacterAnimator : MonoBehaviour
    {
        private static readonly int s_IsRunning = Animator.StringToHash("IsRunning");
        private static readonly int s_IsJumping = Animator.StringToHash("IsJumping");
        private static readonly int s_IsHitting = Animator.StringToHash("IsHitting");
        private static readonly int s_IsTakingDamage = Animator.StringToHash("IsTakingDamage");

        private Animator _animator;
        private AnimatedCharacter _animatedCharacter;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _animatedCharacter = GetComponent<AnimatedCharacter>();
        }

        private void Update()
        {
            SetupAnimations();
        }

        private void SetupAnimations()
        {
            SetupRunningAnimation(_animatedCharacter.IsRunning);
            SetupJumpingAnimation(_animatedCharacter.IsGrounded == false);
            SetupHittingAnimation(_animatedCharacter.IsHitting);
            SetupTakingDamageAnimation(_animatedCharacter.IsTakingDamage);
        }

        private void SetupRunningAnimation(bool value)
        {
            _animator.SetBool(s_IsRunning, value);
        }
    
        private void SetupJumpingAnimation(bool value)
        {
            _animator.SetBool(s_IsJumping, value);
        }
        
        private void SetupHittingAnimation(bool value)
        {
            _animator.SetBool(s_IsHitting, value);
        }
        
        private void SetupTakingDamageAnimation(bool value)
        {
            _animator.SetBool(s_IsTakingDamage, value);

            if (value)
            {
                _animatedCharacter.IsTakingDamage = false;
            }
        }
    }
}
