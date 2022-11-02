using UnityEngine;

public class Folow : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private Vector3 _offSet;

    private float _magnitude = 6f;
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _target.transform.position + _offSet, Time.deltaTime * _magnitude);
    }
}
