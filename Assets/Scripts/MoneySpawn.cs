using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawn : MonoBehaviour
{
    [SerializeField] private Tent _tent;
    [SerializeField] private MonyePack _money;
    [SerializeField] private Transform _spawnPoint;

    private void OnEnable()
    {
        _tent.EnemyInside += InstanceMoney;
    }

    private void Start()
    {
        InstanceMoney();
    }

    private void InstanceMoney()
    {
      var money = Instantiate(_money);
      money.transform.position = _spawnPoint.position + new Vector3(0f,0f,0f);
    }

    private void Position()
    {
        
    }

    private void OnDisable()
    {
        _tent.EnemyInside -= InstanceMoney;
    }
}
