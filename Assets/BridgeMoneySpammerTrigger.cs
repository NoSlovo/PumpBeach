using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeMoneySpammerTrigger : MonoBehaviour
{
    [SerializeField] private Bridg _bridg;
    [SerializeField] private MoneyPanel _prefabMoneyPanel;
    [SerializeField] private float _offset;
    
    private int _instanceCount;

    private void Start()
    {
        InstanceMoneyPanel();
    }

    private void InstanceMoneyPanel()
    {
        var moneyPlanel = Instantiate(_prefabMoneyPanel);
        moneyPlanel.transform.position = new Vector3(0, _instanceCount * _offset, 0);
        _instanceCount++;
    }

}
