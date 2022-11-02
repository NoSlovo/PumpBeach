using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Vector3 = UnityEngine.Vector3;

public class SawmillTriger : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] private float _widthOffset;
    [SerializeField] private float _heightOffset;
    [SerializeField] private BoatSpawn boatSpawn;

    private Stack<Log> _colection = new();
    
    private int _maxLength = 28;
    private int _countElement;
    private float _duration = 2f;
    private float _countDuration;

    public int MaxLength => _maxLength;
    public int CountElement => _countElement;
    public event Action<Log> ThereIsALog;
    public event Action LogInsideColection;

    private void OnTriggerStay(Collider other)
    {
        if (!other.TryGetComponent(out TowerRoot towerRoot))
            return;

        if (_colection.Count >= _maxLength)
            return;

        if (!towerRoot.TryElementColection(out var logElement))
            return;

        logElement.transform.SetParent(transform);
        Build(logElement);
    }

    private void LateUpdate()
    {
        _countDuration += Time.deltaTime;

        if (_duration < _countDuration)
        {
            DropLog();
            _countDuration = 0;
        }
    }

    private void Build(Log element)
    {
        _colection.Push(element);
        _countElement++;
        LogInsideColection?.Invoke();
        var targetPosition = CalculatePosition();
        element.transform.DOMove(targetPosition, 0.1f);
        element.transform.DORotate(new Vector3(-180, 90f, 92f), 0.1f);
    }

    private Vector3 CalculatePosition()
    {
        int maxRowSize = 7;
        var (row, index) = LengthLines(maxRowSize, _colection.Count - 1);
        var targetPostion = _startPosition.position +
                            new Vector3(index * _widthOffset + _widthOffset * (maxRowSize - row) / 2,
                                _heightOffset * (maxRowSize - row), 0);
        ;
        return targetPostion;
    }

    private (int row, int index) LengthLines(int rowSize, int itemIndex)
    {
        if (rowSize == 0)
        {
            return (0, 0);
        }

        if (rowSize > itemIndex)
            return (rowSize, itemIndex);
        return LengthLines(rowSize - 1, itemIndex - rowSize);
    }

    private void DropLog()
    {
        if (boatSpawn.CountInstance <= boatSpawn.MaxBoat)
        {
            
            if (_colection.Count > 0 )
            {
                var log = _colection.Pop();
                _countElement--;
                log.transform.SetParent(null);
                ThereIsALog?.Invoke(log);
            }  
        }
    }
}