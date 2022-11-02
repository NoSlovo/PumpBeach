using System;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Burst;
using UnityEngine;

[BurstCompile]
public class Bonfire : MonoBehaviour
{
    [SerializeField] private List<BonfireLog> _colectionLogs;
    [SerializeField] private ParticleSystem _particleFire;
    [SerializeField] private Transform _pointMove;
    [SerializeField] private int _maxLogs;
    [SerializeField] private SleepingPlace _sleepingPlace;

    private SpawnEnemy _spawnEnemy;
    private int _activeLogsCount;
    private bool _logMove;
    
    public int activeLogsCount => _activeLogsCount;
    public int maxLogs => _maxLogs;
    public int MaxActiveElemnt => _colectionLogs.Count;
    public Transform pointMove => _pointMove;

    public event Action LogInside;
    public event Action<Transform> BonfireActive;
    

    private void OnEnable()
    {
        _sleepingPlace.EnemyExit += EnableElements;
    }

    private void Start()
    {
        EnableElements();
        _particleFire.Stop();
        LogInside?.Invoke();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out TowerRoot tower))
            SetLog(tower);
    }

    private void SetLog(TowerRoot tower)
    {
        int maxCount = _maxLogs == 0 ? _colectionLogs.Count : _maxLogs;

        if (_activeLogsCount < maxCount && _logMove == false)
        {
            if (tower.TryElementColection(out Log log))
            {
                _logMove = true;

                log.transform.DOJump(transform.position, 1f, 1, 0.25f)
                    .OnComplete(() =>
                    {
                        if (maxCount == 1)
                            ActiveFullColection();

                        AddLog(log);

                        if (_activeLogsCount == maxCount)
                        {
                            BonfireActive?.Invoke(_pointMove);
                            _particleFire.Play();
                        }
                    });
            }
        }
    }
    
    private void ActiveFullColection()
    {
        for (int i = 0; i < _colectionLogs.Count ; i++)
        {
            _colectionLogs[i].MeshOn();
        }
    }
    
    private void AddLog(Log log)
    {
        _colectionLogs[_activeLogsCount].MeshOn();
        _activeLogsCount++;
        LogInside?.Invoke();
        _logMove = false;
        Destroy(log.gameObject);
    }

    private void EnableElements()
    {
        _particleFire.Stop();
        _activeLogsCount = 0;
        for (int i = 0; i < _colectionLogs.Count; i++)
        {
            _colectionLogs[i].MeshOff();
        }
        LogInside?.Invoke();
    }


    private void OnDisable()
    {
        _sleepingPlace.EnemyExit -= EnableElements;
    }
}