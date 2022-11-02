using System.Collections.Generic;
using Reflex;
using Reflex.Scripts.Attributes;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemy : MonoBehaviour
{
   [SerializeField] private List<Enemy> _enemyPrefabs;
   [SerializeField] private Bridg _bridg;
    
   private List<Bonfire> _bonfireColection;
   
   [Inject]
   private void Construct(Container container)
   {
       _bonfireColection = container.Resolve<List<Bonfire>>();
   }

   private void OnEnable()
   {
       Listen();
       _bridg.BoatCreate += CreateAndMove;
   }

   private void CreateAndMove(Transform entryPoint)
   {
     var numberEnemy =  Random.Range(0, _enemyPrefabs.Count);
     var enemy = _enemyPrefabs[numberEnemy];
     var createEnemy = Instantiate(enemy);
     createEnemy.MoveToPoint(entryPoint);
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
   private void OnDisable()
   {
       _bridg.BoatCreate -= CreateAndMove;
       StopListening();
   }

}
