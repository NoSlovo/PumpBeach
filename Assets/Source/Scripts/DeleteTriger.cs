using UnityEngine;

public class DeleteTriger : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
      if (other.TryGetComponent(out Enemy enemy))
      {
         Destroy(enemy);
      }
   }
}
