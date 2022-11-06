using UnityEngine;

public class MoneyTower : MonoBehaviour
{
    private Tower<Money> _towerMoney = new ();
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
    
    private void PutElement(Money collectable)
    {
        _towerMoney.SetTransform(this.transform);
        _towerMoney.PutElement(collectable);
    }
     
 }