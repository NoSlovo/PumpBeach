using UnityEngine;

public class MoneySpawn : MonoBehaviour
{
    [SerializeField] private SleepingPlace _sleepingPlace;
    [SerializeField] private MonyePack _money;
    [SerializeField] private Transform _spawnPoint;

    private void OnEnable()
    {
        _sleepingPlace.EnemyExit += InstanceMoney;
    }
    
    private void InstanceMoney()
    {
      var money = Instantiate(_money);
    }

    private void OnDisable()
    {
        _sleepingPlace.EnemyExit -= InstanceMoney;
    }
}
