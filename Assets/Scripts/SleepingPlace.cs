using System;
using UnityEngine;

public class SleepingPlace : MonoBehaviour
{
    [SerializeField] protected Bonfire _bonfire;
    [SerializeField] protected Transform _endPoint;
    [SerializeField] protected DeleteTriger _deleteEnemyPoint;
    [SerializeField] protected MoneySpawn _moneySpawn;

    public event Action EnemyInside;
    
    protected void MoneySpawn()
    {
        EnemyInside?.Invoke();
    }
}