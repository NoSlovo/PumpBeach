using UnityEngine;

public class TrigerSpawner : MonoBehaviour
{
  [SerializeField] private LogSpawner _logSpawner;
  
  private void OnTriggerStay(Collider other)
  {
    if (other.TryGetComponent(out TowerRoot _tower))
    {
      if (_tower.TowerFull != true)
      {
        if (_logSpawner.TryColectionLog(out var log))
        {
          _tower.PutElement(log);
        } 
      }
    }
  }
}
