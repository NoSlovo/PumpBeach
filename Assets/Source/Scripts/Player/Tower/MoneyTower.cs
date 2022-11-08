using System;
using System.Collections;
using UnityEngine;

public class MoneyTower : TowerBuilder<Money>
{
    [SerializeField] private TowerRoot _logTower;
    
    private static int _countElements;
    private void OnTriggerEnter(Collider other)
     {
         if (other.TryGetComponent(out Money money))
         {
             var createMoney = Instantiate(money);
             createMoney.transform.position = money.transform.position;
             Destroy(money.gameObject);
             if (_logTower.CurrenCount == 0)
             {
                 PutElement(createMoney);
                 StartCoroutine(DestrouTower());
             }
         }
     }


    private IEnumerator DestrouTower()
    {
        var waitForSecondsRealtime = new WaitForSecondsRealtime(1f);
        while (CurrentCount != 0)
        {
            if (TryElementColection(out Money money))
            {
                Destroy(money.gameObject);
                yield return waitForSecondsRealtime;
                RefreshPosition();
            }
            yield return waitForSecondsRealtime;
        }
    }
    
    
}