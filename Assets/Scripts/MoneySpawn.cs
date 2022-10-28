using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawn : MonoBehaviour
{
    [SerializeField] private SleepingPlace _sllepingPlace;
    [SerializeField] private Money _money;
    [SerializeField] private List<Money> _moneyColection;

    private void OnEnable()
    {
        _sllepingPlace.EnemyInside += InstanceMoney;
    }

    private void InstanceMoney()
    {
      var money = Instantiate(_money);
      _moneyColection.Add(money);
      money.transform.position = transform.position;
    }

    private void OnDisable()
    {
        _sllepingPlace.EnemyInside -= InstanceMoney;
    }
}
