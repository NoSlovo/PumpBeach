using System;
using UnityEngine;

public class TrigerSaw : MonoBehaviour
{
    [SerializeField] private Saw _saw;
    private int _count;
    private Log _log;
    private float _timeDuration;

    public event Action WoodInside;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Log log))
        {
            _log = log;
            WoodInside?.Invoke();
        }
    }

    public void DeleteItem()
    {
        if (_log != null)
        {
            Destroy(_log.gameObject);
        }
    }
}
