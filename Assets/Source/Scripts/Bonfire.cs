using System;
using System.Collections.Generic;
using DG.Tweening;
using JetBrains.Annotations;
using Reflex;
using Reflex.Scripts.Attributes;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
    [SerializeField] private List<BonfireLog> _colection;
    [SerializeField] private ParticleSystem _psFire;
    [SerializeField, NotNull] private Transform _entryPosition;
    [SerializeField] private int _maximumLogs;
    
    private SpawnEnemy _spawnEnemy;
    private int _activeCount;
    private bool _logMove;
    
    public int ActiveCount => _activeCount;
    public int MaximumLogs => _maximumLogs;
    public int MaxActiveElemnt => _colection.Count;

    public event Action LogInside;
    
    [Inject]
    private void Construct(Container container)
    {
        _spawnEnemy = container.Resolve<SpawnEnemy>();
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

                log.transform.DOJump(transform.position, 1f, 1, 0.25f).OnComplete(() =>
                {
                    if (maxCount == 1)
                        ActiveFullColection();
                    
                    _colection[_activeCount].MeshOn();
                    _activeCount++;
                    LogInside?.Invoke();
                    _logMove = false;
                    Destroy(log.gameObject);

                    if (_activeCount == maxCount)
                    {
                        _spawnEnemy.CreateAndMove(_entryPosition);
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

    private void EnableElemenst()
    {
        for (int i = 0; i < _colection.Count; i++)
        {
            _colection[i].MeshOff();
        }
    }
}