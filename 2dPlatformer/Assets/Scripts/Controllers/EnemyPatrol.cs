using System;
using Models;
using UnityEngine;

namespace Controllers
{
    [RequireComponent(typeof(AnimatedCharacter), typeof(Enemy))]
    public class EnemyPatrol : MonoBehaviour
    {
        private const float MinDistanceToPoint = 0.5f;

        [SerializeField] private Transform _pointA;
        [SerializeField] private Transform _pointB;
        [SerializeField] private float _speed = 2f;
        
        private AnimatedCharacter _animatedCharacter;
        private Enemy _enemy;
        private Transform _currentPoint;

        private void Awake()
        {
            _animatedCharacter = GetComponent<AnimatedCharacter>();
            _enemy = GetComponent<Enemy>();
        }

        private void Start()
        {
            _currentPoint = _pointB;
        }

        private void Update()
        {
            Patrol();
            ProhibitLeavingPointsZone();
        }

        private void Patrol()
        {
            if (_enemy.IsPatrolling == false)
            {
                return;
            }

            _animatedCharacter.IsRunning = true;
            transform.position= Vector2.MoveTowards(transform.position, _currentPoint.position, _speed * Time.deltaTime);
            
            var distance = Vector2.Distance(transform.position, _currentPoint.position);

            if (distance <= MinDistanceToPoint == false)
            {
                return;
            }
            
            _currentPoint = _currentPoint == _pointA ? _pointB : _pointA;
            Flip();
        }

        private void Flip()
        {
            var localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }

        private void ProhibitLeavingPointsZone()
        {
            transform.position = new Vector2(
                Mathf.Clamp(transform.position.x, _pointA.position.x, _pointB.position.x),
                transform.position.y
            );
        }
    }
}
