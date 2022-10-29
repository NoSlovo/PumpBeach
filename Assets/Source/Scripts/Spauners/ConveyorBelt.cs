using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
 [SerializeField] private Material _material;
 [SerializeField] private float _speadMove;

 private float _duration = -0.4f;

 private void FixedUpdate()
 {
  _material.mainTextureOffset += new Vector2(_speadMove * Time.deltaTime  * _duration, 0);
 }
}
