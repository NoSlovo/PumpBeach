using System;
using DG.Tweening;
using UnityEngine;

public class SawAnimation : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Saw _saw;
    [SerializeField] private TrigerSaw _trigerSaw;

    private int _deleteCounter;
    private int _maximumLogsRemoved = 2;
    public event Action LogsDestroyed;
    private void OnEnable()
    {
        _trigerSaw.WoodInside += AnimationMove;
    }

    private void AnimationMove()
    {
        bool animationStart = true;
        _saw.StartRotation(animationStart);
        transform.DOMove(_target.position, 0.8f).SetLoops(2,LoopType.Yoyo).OnComplete(() =>
        { 
            animationStart = false;
            _saw.StartRotation(animationStart);
            _trigerSaw.DeleteItem();
            _deleteCounter++;
            if (_deleteCounter == _maximumLogsRemoved)
            {
                LogsDestroyed?.Invoke();
                _deleteCounter = 0;
            }
        });
    }

    private void OnDisable()
    {
        _trigerSaw.WoodInside -= AnimationMove;
    }
}
