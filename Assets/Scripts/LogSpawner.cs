using System;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Burst;
using UnityEngine;

[BurstCompile]
public class LogSpawner : MonoBehaviour
{
    [SerializeField] private Log _logObject;
    [SerializeField] private Transform _lastPosition;
    [SerializeField] private float _heightOffset;
    [SerializeField] private float _widthOffset;
    public event Action<int> SpawnLog;
    
    private Stack<Log> _logColection = new();

    private float _duration = 1f;
    private float _timeDuration;
    private int _logCount;

    public int CountColection => _logColection.Count;

    private void FixedUpdate()
    {
        _timeDuration += Time.deltaTime;
        FillTheCollection();
    }

    private void FillTheCollection()
    {
        if (_duration < _timeDuration)
        { 
            _timeDuration = 0;
           Spawn();
        }
    }
    
    private void Spawn()
    {
        if (_logCount <= 27)
        {
            var log = Instantiate(_logObject);
            _logCount++;
            log.transform.position = transform.position;
            log.transform.DOMove(transform.position + new Vector3(3f, 0f, 0f), 0.5f)
                .OnComplete(() =>
                {
                    log.transform.DORotate(new Vector3(-90f, -5f, +5f), 0.3f);
                    Put(log);
                });
        }
    }
    
    

    private void Put(Log log)
    {
        var targetPosition = CalculatePosition();
        log.transform.DOMove(targetPosition, 0.28f).OnComplete(() =>
        {
            _logColection.Push(log);
            SpawnLog?.Invoke(CountColection);
        });
    }
    
    public bool TryColectionLog(out Log log)
    {
        if (_logColection.Count > 0)
        {
            var logColection  = _logColection.Pop();
            _logCount--;
            SpawnLog?.Invoke(CountColection);
            log = logColection;
            return true;
        }
        log = null;
        return false;
    }
    
    private Vector3 CalculatePosition()
    {
        int maxRowSize = 7;
        var (row, index) = LengthLines(maxRowSize, _logCount - 1);
        var targetPostion = _lastPosition.position + new Vector3(index * _widthOffset + _widthOffset * (maxRowSize - row) / 2, _heightOffset * (maxRowSize - row), 0);
        
        return targetPostion;
    }
    
    private (int row, int index) LengthLines(int rowSize, int itemIndex)
    {
        if (rowSize == 0)
            return (rowSize = 1,itemIndex = 1);
        
        if ( rowSize > itemIndex)
            return (rowSize, itemIndex);
        return LengthLines(rowSize - 1, itemIndex - rowSize);
    }
}