using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Lib;
using UnityEngine;

public class TowerRoot : MonoBehaviour
{
    private float _itemHeight = 0.20f;
    private Stack<Log> _logSteck = new();
    private bool _isRefreshExecuted = false;
    private float _spead = 0.5f;
    private int _maxLengthColetion = 20;
    private int _currentCount = 0;

    public int CurrenCount => _currentCount;
    public bool TowerFull => _currentCount == _maxLengthColetion;

    private void OnValidate()
    {
        _logSteck.ForEachIndexed((log, index) =>
            log.transform.localPosition = log.transform.localPosition.Copy(x: 0, index * _itemHeight, 0));
    }

    public void PutElement(Log collectable)
    {
        if (TowerFull)
            return;

        var targetPosition = new Vector3(0, _currentCount * _itemHeight, 0);
        _currentCount++;
        collectable.transform.SetParent(transform);
        collectable.transform.DOLocalJump(targetPosition, 1f, 1, 0.3f)
            .OnComplete(() =>
            {
                _logSteck.Push(collectable);
                RefreshLogPosition();
            });
        collectable.transform.DOLocalRotate(new Vector3(90f, 100f, 0f), 0.1f).OnComplete(() =>
        {
            var targetRotation = new Vector3(90f, 100f, 0f);
            collectable.transform.DOLocalRotate(targetRotation, 0);
        });
    }

    private void RefreshLogPosition()
    {
        if (!_isRefreshExecuted)
            StartCoroutine(UpdatePositions());
    }


    private IEnumerator UpdatePositions()
    {
        _isRefreshExecuted = true;
        bool needUpdate = false;

        do
        {
            needUpdate = false;
            
            _logSteck.ForEachIndexed((log, i) =>
            {
                int index = _logSteck.Count - i - 1;
                var targetPosition = new Vector3(0, index * _itemHeight, 0);
                log.transform.localPosition = Vector3.MoveTowards(
                        log.transform.localPosition,
                        targetPosition,
                        _itemHeight / _spead * Time.deltaTime);

                needUpdate = needUpdate || log.transform.localPosition != targetPosition;
            });

            yield return null;
        } while (needUpdate);
    }

    public bool TryElementColection(out Log log)
    {
        if (_logSteck.Count > 0)
        {
            _currentCount--;
            var elemntColection = _logSteck.Pop();
            elemntColection.transform.SetParent(null);
            log = elemntColection;
            return true;
        }
        
        log = null;
        return false;
    }
    
    
}