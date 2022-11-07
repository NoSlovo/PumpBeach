using System;
using Unity.Burst;
using UnityEngine;

[BurstCompile]
public class TowerRoot : TowerBuilder<Log>
{
    [SerializeField] private MoneyTower _moneyTower;
    public int CurrenCount => _currentCount;
    
}