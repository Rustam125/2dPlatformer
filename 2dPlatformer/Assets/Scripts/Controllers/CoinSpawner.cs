using System.Collections;
using System.Collections.Generic;
using Models;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

namespace Controllers
{
    public class CoinSpawner : MonoBehaviour
    {
        [SerializeField] private Coin _coinPrefab;
        [SerializeField] private List<Transform> _points;
        [SerializeField] private float _spawnDelay = 3f;

        private Coroutine _coroutine;
        private Coin _coinCache;
        private ObjectPool<Coin> _coinsPool;
        private Transform _currentPoint;
    
        private void Awake()
        {
            _currentPoint = GetRandomPoint();
            _coinsPool = new ObjectPool<Coin>(
                createFunc: () => Instantiate(_coinPrefab, transform),
                actionOnGet: InitCoin,
                actionOnDestroy: Destroy);
        }
        
        private void Start()
        {
            _coroutine = StartCoroutine(Spawn());
        }

        private void OnDisable()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }

        private void InitCoin(Coin coin)
        {
            coin.transform.position = _currentPoint.position;
        }
        
        private IEnumerator Spawn()
        {
            var wait = new WaitForSeconds(_spawnDelay);
            
            while (enabled)
            {
                _currentPoint = GetRandomPoint();

                if (HasCoinInPoint(_currentPoint.position) == false)
                {
                    _coinsPool.Get();
                }
                
                yield return wait;
            }
        }

        private bool HasCoinInPoint(Vector2 position)
        {
            var point = Physics2D.OverlapPoint(position);
            return point?.gameObject.TryGetComponent<Coin>(out _) ?? false;
        }
        
        private Transform GetRandomPoint() =>
            _points[Random.Range(0, _points.Count)];
    }
}
