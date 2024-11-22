using Models;
using UnityEngine;

namespace Controllers
{
    [RequireComponent(typeof(Animator), typeof(AnimatedCharacter))]
    public class CharacterAnimator : MonoBehaviour
    {
        private static readonly int s_IsRunning = Animator.StringToHash("IsRunning");
        private static readonly int s_IsJumping = Animator.StringToHash("IsJumping");
        
        private Animator _animator;
        private AnimatedCharacter _animatedCharacter;

        private void Start()
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
        }

        private void SetupRunningAnimation(bool value)
        {
            _animator.SetBool(s_IsRunning, value);
        }
    
        private void SetupJumpingAnimation(bool value)
        {
            _animator.SetBool(s_IsJumping, value);
        }
    }
}
