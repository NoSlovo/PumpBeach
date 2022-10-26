using System.Collections;
using UnityEngine;

public class Bridg : MonoBehaviour
{
   [SerializeField] private Transform _targetPosition;
   [SerializeField] private ParticleSystem _particleSystem;
   [SerializeField] private BoatSpawn _boatSpawn;
   [SerializeField]private SpawnEnemy _spawnEnemy;
      

   private void Awake()
   {
      _particleSystem.Stop();
   }

   private void OnEnable()
   {
      _boatSpawn.BoatDesigned += ComeHere;
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.TryGetComponent(out Enemy enemy))
      {
         enemy.StopMove();
         PlaceInBoat(enemy);
      }
   }


   private void ComeHere()
   {
      _spawnEnemy.CreateAndMove(_targetPosition);
   }

   private void PlaceInBoat(Enemy enemy)
   {
      if (_boatSpawn.GetCreatedItem(out Boat boat))
      {
         var instantiateEnemy = Instantiate(enemy);
         Destroy(enemy.gameObject);
         instantiateEnemy.transform.SetParent(boat.transform);
         instantiateEnemy.transform.position = boat.transform.position;
         _particleSystem.Play();
         instantiateEnemy.Sit();
         instantiateEnemy.transform.rotation = boat.transform.rotation;
         boat.Move();
         StartCoroutine(RunRefreshBoatsPosition());
      }
   }
   
   private IEnumerator RunRefreshBoatsPosition()
   {
      var waitForSecondsRealtime = new WaitForSecondsRealtime(0.7f);
      yield return waitForSecondsRealtime;
      _boatSpawn.RefreshBoatPosition();
   }

   private void OnDisable()
   {
      _boatSpawn.BoatDesigned -= ComeHere;
   }
}

