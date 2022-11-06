using System;
using Unity.Burst;
using UnityEngine;

[BurstCompile]
public class TowerRoot : MonoBehaviour
{
    private Tower<Log> _logTower;

    public int CurrenCount => _logTower.CurrentCount;
    public bool TowerFull => _logTower.TowerFull;

    public TowerRoot()
    {
        _logTower = new ();
    }

    public void PutElement(Log collectable)
    {
        _logTower.SetTransform(this.transform);
        _logTower.PutElement(collectable);
    }
    
    public bool TryElementColection(out Log log)
    {
        if (_logTower.TryElementColection(out Log item))
        {
            log = item;
            return true;
        };
        log = null;
        return false;
    }
    
    
}