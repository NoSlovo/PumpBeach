using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
    [SerializeField] private List<BonfireLog> _colection;
    [SerializeField] private ParticleSystem _psFire;
    [SerializeField] private Transform _entryPosition;
    [SerializeField] private int _maximumLogs;
    [SerializeField] private SleepingPlace _sleepingPlace;
    
    private SpawnEnemy _spawnEnemy;
    private int _activeCount;
    private bool _logMove;
    
    public int ActiveCount => _activeCount;
    public int MaximumLogs => _maximumLogs;
    public int MaxActiveElemnt => _colection.Count;
    public Transform EntryPosition => _entryPosition;

    public event Action LogInside;
    public event Action<Transform> BonfireActive;
    

    private void OnEnable()
    {
        _sleepingPlace.EnemyExit += EnableElemenst;
    }

    private void Start()
    {
        EnableElemenst();
        _psFire.Stop();
        LogInside?.Invoke();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out TowerRoot tower))
            SetLog(tower);
    }

    private void SetLog(TowerRoot tower)
    {
        int maxCount = _maximumLogs == 0 ? _colection.Count : _maximumLogs;

        if (_activeCount < maxCount && _logMove == false)
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

                        if (_activeCount == maxCount)
                        {
                            BonfireActive?.Invoke(_entryPosition);
                            _psFire.Play();
                        }
                    });
            }
        }
    }
    
    private void ActiveFullColection()
    {
        for (int i = 0; i < _colection.Count ; i++)
        {
            _colection[i].MeshOn();
        }
    }
    
    private void AddLog(Log log)
    {
        _colection[_activeCount].MeshOn();
        _activeCount++;
        LogInside?.Invoke();
        _logMove = false;
        Destroy(log.gameObject);
    }

    private void EnableElemenst()
    {
        _psFire.Stop();
        _activeCount = 0;
        for (int i = 0; i < _colection.Count; i++)
        {
            _colection[i].MeshOff();
        }
        LogInside?.Invoke();
    }


    private void OnDisable()
    {
        _sleepingPlace.EnemyExit -= EnableElemenst;
    }
}