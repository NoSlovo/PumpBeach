using System;
using System.Collections.Generic;
using Reflex;
using Reflex.Scripts.Attributes;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemy : MonoBehaviour
{
   [SerializeField] private List<Enemy> _enemyColection;
   [SerializeField] private Bridg _bridg;
    
   private List<Bonfire> _bonfireColection;
   
   [Inject]
   private void Construct(Container container)
   {
       _bonfireColection = container.Resolve<List<Bonfire>>();
   }

   public void OnEnable()
   {
       Listen();
       _bridg.BoatCreate += CreateAndMove;
   }

   private void CreateAndMove(Transform entryPoint)
   {
     var numberEnemy =  Random.Range(0, _enemyColection.Count);
     var enemy = _enemyColection[numberEnemy];
     var createEnemy = Instantiate(enemy);
     createEnemy.MoveToPoint(entryPoint);
   }

   public void OnDisable()
   {
       _bridg.BoatCreate -= CreateAndMove;
       StopListening();
   }

   private void Listen()
   {
       _bonfireColection.ForEach((bonfire) =>
       {
           bonfire.BonfireActive += CreateAndMove;
       });
   }

   private void StopListening()
   {
       _bonfireColection.ForEach((bonfire) =>
       {
           bonfire.BonfireActive -= CreateAndMove;
       });
   }
}
