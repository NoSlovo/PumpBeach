using UnityEngine;
public class Saw : MonoBehaviour
{
   [SerializeField] private SawAnimation moveSawAnimation;
   private bool _startSpinning;
   private float _speadRotattion = 155f;
   

   private void Update()
   {
      if (_startSpinning)
      {
         transform.Rotate(new Vector3(0,0,5f * _speadRotattion * Time.deltaTime));  
      }
   }

   public void StartRotation(bool _start)
   {
      _startSpinning = _start;
   }
   
}
