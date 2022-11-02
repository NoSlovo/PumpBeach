using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Bridg : MonoBehaviour
{
   [SerializeField] private Transform _targetPosition;
   [SerializeField] private ParticleSystem _particleSystem;
   [SerializeField] private BoatSpawn _boatSpawn;

   public event Action<Transform> BoatCreate;
   
   private void Awake()
   {
      _particleSystem.Stop();
   }

   private void OnEnable()
   {
      _boatSpawn.BoatDesigned += CallHere;
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.TryGetComponent(out Enemy enemy))
      {
         enemy.StopMove();
         CreateInTheBoat(enemy);
      }
   }


   private void CallHere()
   {
      BoatCreate.Invoke(_targetPosition);
   }

   private void CreateInTheBoat(Enemy enemy)
   {
      if (_boatSpawn.GetCreatedItem(out Boat boat))
      {
         var instantiateEnemy = Instantiate(enemy);
         instantiateEnemy.transform.position = boat.transform.position;
         instantiateEnemy.transform.rotation = boat.transform.rotation;
         _particleSystem.Play();
         instantiateEnemy.Sit();
         instantiateEnemy.transform.SetParent(boat.transform);
         boat.Move();
         Destroy(enemy.gameObject);
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
      _boatSpawn.BoatDesigned -= CallHere;
   }
}

