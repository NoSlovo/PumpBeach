using UnityEngine;

public class MoneySpawn : MonoBehaviour
{
    [SerializeField] private SleepingPlace _sleepingPlace;
    [SerializeField] private MonyePack _money;

    private void OnEnable()
    {
        _sleepingPlace.EnemyExit += InstanceMoney;
    }
    
    private void InstanceMoney()
    {
      var money = Instantiate(_money);
      money.transform.position = transform.position;
    }

    private void OnDisable()
    {
        _sleepingPlace.EnemyExit -= InstanceMoney;
    }
}
