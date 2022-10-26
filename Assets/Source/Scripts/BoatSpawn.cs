using System;
using System.Collections.Generic;
using DG.Tweening;
using Lib;
using UnityEngine;

public class BoatSpawn : MonoBehaviour
{
    [SerializeField] private Boat _boat;
    [SerializeField] private Transform _endLine;
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private SawAnimation _sawAnimation;

    private Queue<Boat> _colectionBoat = new();
    private float _offset = 1.25f;
    private int _maxBoatSpawn = 2;
    private int _countInstance;
    public event Action BoatDesigned;

    public int MaxBoat => _maxBoatSpawn;
    public int CountInstance => _countInstance;


    private void OnEnable()
    {
        _sawAnimation.LogsDestroyed += Create;
    }

    private void Create()
    {
        var boat = Instantiate(_boat);
        _countInstance++;
        boat.transform.position = transform.position;
        boat.transform.DOMove(_endLine.position, 1f).OnComplete(() =>
        {
            boat.transform.DOMove(_targetPosition.position + new Vector3(_colectionBoat.Count * _offset * -1, 0, 0),
                1f);
            BoatDesigned?.Invoke();
            _colectionBoat.Enqueue(boat);
        });
    }

    private void OnDisable()
    {
        _sawAnimation.LogsDestroyed -= Create;
    }

    public bool GetCreatedItem(out Boat boat)
    {
        if (_colectionBoat.Count > 0)
        {
            boat = _colectionBoat.Dequeue();
            _countInstance--;
            return true;
        }

        boat = null;
        return false;
    }
    
    public void RefreshBoatPosition()
    {
        _colectionBoat.ForEachIndexed((i, Index) =>
        {
            var targetPositiond = _targetPosition.position + new Vector3(Index * _offset * -1, 0, 0);
            i.transform.DOMove(targetPositiond, 0.6f);
        });
    }
}