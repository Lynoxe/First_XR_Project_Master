using UnityEngine;
using System.Collections.Generic;

public class BallDispenser : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private float _spawnDistanceThreshold = 0.5f;
    [SerializeField] private int _maxBallCount = 5;

    private Queue<Transform> _spawnedBalls;
    private Transform _lastSpawnedBall;
    private Vector3 _initialPos;
    private float _sqrSpawnDistanceThreshold;

    private void Start()
    {
        _spawnedBalls = new Queue<Transform>(_maxBallCount);

        SpawnBall();
        _sqrSpawnDistanceThreshold = _spawnDistanceThreshold * _spawnDistanceThreshold;
    }

    private void Update()
    {
        if((_lastSpawnedBall.position - _initialPos).sqrMagnitude > _sqrSpawnDistanceThreshold)
        {
            SpawnBall();
        }

    }

    private void SpawnBall()
    {
        _lastSpawnedBall = Instantiate(_ballPrefab, _spawnPoint.position + Vector3.up * _ballPrefab.transform.localScale.y, Quaternion.identity).transform;
        _initialPos = _lastSpawnedBall.position;

        if(_spawnedBalls.Count >= _maxBallCount)
        {
            var ballToDelete = _spawnedBalls.Dequeue();
            Destroy(ballToDelete.gameObject);
        }
        _spawnedBalls.Enqueue(_lastSpawnedBall);
    }

    private void OnValidate()
    {
        if (_maxBallCount <= 1)
            _maxBallCount = 2;
    }
}
