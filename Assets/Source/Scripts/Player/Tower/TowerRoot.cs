using System;
using Unity.Burst;
using UnityEngine;

[BurstCompile]
public class TowerRoot : TowerBuilder<Log>
{
    [SerializeField] private MoneyTower _moneyTower;
    public int CurrenCount => _currentCount;

    public void PutLog(Log log)
    {
        if (_moneyTower.CurrentCount == 0)
        {
            PutElement(log);
        }
    }
    
}