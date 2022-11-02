using System;
using System.Collections.Generic;
using DG.Tweening;
using Lib;
using UnityEngine;

[ExecuteAlways]
public class MoneySpawn : MonoBehaviour
{
    [SerializeField] private SleepingPlace _sleepingPlace;
    [SerializeField] private Money _money;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private int _MaxSpawn;

    private float _offset = 0.1f;

    private List<Money> _moneyColection = new ();

    private void OnEnable()
    {
        _sleepingPlace.EnemyExit += Instance;
    }
    
    private void Instance()
    {
        for (int i = 0; i < _MaxSpawn; i++)
        {
            var money = Instantiate(_money,_startPosition);
            money.transform.position = _startPosition.position;
            _moneyColection.Add(money);
            MoveMoneyPosition();   
        }
    }


    private void MoveMoneyPosition()
    {
        _moneyColection.ForEachIndexed((i, Index) =>
        {
            var targetPosition = _startPosition.position + new Vector3(0, Index * 0.1f + _offset, 0);
            i.transform.DOMove(targetPosition, 0.1f);
        });
    }
    

    private void OnDisable()
    {
        _sleepingPlace.EnemyExit -= Instance;
    }
}
