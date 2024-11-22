using Models;
using UnityEngine;

namespace Controllers
{
    [RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(AnimatedCharacter))]
    public class PlayerMover : MonoBehaviour
    {
        private const string Horizontal = nameof(Horizontal);
    
        [SerializeField] private float _speed = 5f;
    
        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _spriteRenderer;
        private AnimatedCharacter _animatedCharacter;
        private float _horizontalInput;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _animatedCharacter = GetComponent<AnimatedCharacter>();
        }

        private void Update()
        {
            Move();
            Flip();
        }

        private void Move()
        {
            _horizontalInput = Input.GetAxis(Horizontal);
            _rigidbody2D.velocity = new Vector2(_speed * _horizontalInput, _rigidbody2D.velocity.y);
            _animatedCharacter.IsRunning = _horizontalInput != 0;
        }

        private void Flip()
        {
            if (_horizontalInput == 0)
            {
                return;
            }

            _spriteRenderer.flipX = _horizontalInput < 0;
        }
    }
}
