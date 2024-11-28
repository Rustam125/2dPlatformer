using Helpers;
using Models;
using UnityEngine;

namespace Controllers
{
    [RequireComponent(typeof(AnimatedCharacter), typeof(Enemy))]
    public class PlayerChaser : MonoBehaviour
    {
        [SerializeField] private float _viewingDistance = 10f;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _minDistance = 1f;
        [SerializeField] private float _speed = 3f;

        private AnimatedCharacter _animatedCharacter;
        private Enemy _enemy;
        private Player _player;

        private void Awake()
        {
            _animatedCharacter = GetComponent<AnimatedCharacter>();
            _enemy = GetComponent<Enemy>();
        }

        private void FixedUpdate()
        {
            Chase();
        }

        private void Chase()
        {
            if (MainHelper.IsSeeGameObject(transform, _viewingDistance, _layerMask, out _player) == false || 
                _player is null)
            {
                _enemy.IsPatrolling = true;
                return;
            }

            _animatedCharacter.IsRunning = true;
            _enemy.IsPatrolling = false;
            var playerPosition = _player.gameObject.transform.position;
            
            var distance = Vector2.Distance(transform.position, playerPosition);

            if (distance <= _minDistance)
            {
                _animatedCharacter.IsRunning = false;

                return;
            }
            
            transform.position= Vector2.MoveTowards(transform.position, playerPosition, _speed * Time.deltaTime);
        }
    }
}