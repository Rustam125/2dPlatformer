using Models;
using UnityEngine;

namespace Controllers
{
    [RequireComponent(typeof(AnimatedCharacter))]
    public class EnemyPatrol : MonoBehaviour
    {
        private const float MinDistanceToPoint = 0.5f;

        [SerializeField] private GameObject _pointA;
        [SerializeField] private GameObject _pointB;
        [SerializeField] private float _speed = 2f;
        
        private AnimatedCharacter _animatedCharacter;
        private Transform _currentPoint;
        
        private void Start()
        {
            _animatedCharacter = GetComponent<AnimatedCharacter>();
            _animatedCharacter.IsRunning = true;
            _currentPoint = _pointB.transform;
        }

        private void Update()
        {
            Patrol();
        }

        private void Patrol()
        {
            transform.position= Vector2.MoveTowards(transform.position, _currentPoint.position, _speed * Time.deltaTime);
            
            var distance = Vector2.Distance(transform.position, _currentPoint.position);

            if (distance <= MinDistanceToPoint == false)
            {
                return;
            }
            
            _currentPoint = _currentPoint == _pointA.transform ? _pointB.transform : _pointA.transform;
            Flip();
        }

        private void Flip()
        {
            var localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
}
