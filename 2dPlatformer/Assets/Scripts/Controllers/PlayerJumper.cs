using Models;
using UnityEngine;

namespace Controllers
{
    [RequireComponent(typeof(Rigidbody2D), typeof(AnimatedCharacter))]
    public class PlayerJumper : MonoBehaviour
    {
        private const string JumpButton = "Jump";

        [SerializeField] private float _jumpForce = 300f;
    
        private Rigidbody2D _rigidbody2D;
        private AnimatedCharacter _animatedCharacter;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animatedCharacter = GetComponent<AnimatedCharacter>();
        }

        private void Update()
        {
            Jump();
        }

        private void Jump()
        {
            if (Input.GetButtonDown(JumpButton) == false)
            {
                return;
            }
        
            _rigidbody2D.AddForce(new Vector2(_rigidbody2D.velocity.x, _jumpForce));
            _animatedCharacter.IsGrounded = false;
        }
    }
}
