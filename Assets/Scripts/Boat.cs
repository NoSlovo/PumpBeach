using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Boat : MonoBehaviour
{
 [SerializeField] private Animator _animator;
 [SerializeField] private Transform _instanceEnemy;

 public Transform InstanceEnemy => _instanceEnemy;
 
 
 private void Awake()
 {
  _animator.enabled = false;
 }

 public void Move()
 {
  _animator.enabled = true;
  _animator.Play(BaseAnimation.BoatSwim);
 }

 public void Delete()
 {
  Destroy(gameObject);
 }


}
