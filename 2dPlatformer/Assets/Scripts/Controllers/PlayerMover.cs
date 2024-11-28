using Models;
using UnityEngine;

namespace Controllers
{
    [RequireComponent(typeof(Rigidbody2D), typeof(AnimatedCharacter))]
    public class PlayerMover : MonoBehaviour
    {
        private const string Horizontal = nameof(Horizontal);
    
        [SerializeField] private float _speed = 5f;
        [SerializeField] private InputReader _input;
        
        private Rigidbody2D _rigidbody2D;
        private AnimatedCharacter _animatedCharacter;
        private float _horizontalInput;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animatedCharacter = GetComponent<AnimatedCharacter>();
        }
        
        private void OnEnable()
        {
            _input.Moved += Move;
        }
        
        private void FixedUpdate()
        {
            Flip();
        }

        private void OnDisable()
        {
            _input.Moved -= Move;
        }

        private void Move(float horizontalInput)
        {
            _horizontalInput = horizontalInput;
            _rigidbody2D.velocity = new Vector2(_speed * _horizontalInput, _rigidbody2D.velocity.y);
            _animatedCharacter.IsRunning = _horizontalInput != 0;
        }

        private void Flip()
        {
            if (_horizontalInput == 0)
            {
                return;
            }
            
            var localScale = transform.localScale;

            if ((localScale.x < 0 && _horizontalInput < 0) ||
                (localScale.x > 0 && _horizontalInput > 0))
            {
                return;
            }
            
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
}
