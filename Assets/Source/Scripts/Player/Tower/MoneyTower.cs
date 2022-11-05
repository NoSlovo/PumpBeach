using System;
using UnityEngine;

public class MoneyTower : TowerBuilder<Money>
{
    private static int _countElements;
    private void OnTriggerEnter(Collider other)
     {
         if (other.TryGetComponent(out Money money))
         {
             var createMoney = Instantiate(money);
             createMoney.transform.position = money.transform.position;
             Destroy(money.gameObject);
             PutElement(createMoney);
         }
     }
}