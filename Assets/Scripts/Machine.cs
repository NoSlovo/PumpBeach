using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Machine : MonoBehaviour
{
    [SerializeField] private SawmillTriger _triger;
    [SerializeField] private Transform _target;

    private int coun;

    private void OnEnable()
    {
        _triger.ThereIsALog += StartWork;
    }

    private void StartWork(Log log)
    {
        StartCoroutine(GetLog(log));
    }

    private IEnumerator GetLog(Log log)
    {
        var waitForSecondsRealtime = new WaitForSecondsRealtime(1f);
        yield return waitForSecondsRealtime;
        log.transform.DOJump(_target.position,1f, 1,0.3f);
    }

    private void OnDisable()
    {
        _triger.ThereIsALog -= StartWork;
    }
}