using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private TowerRoot _tower;
    public TowerRoot Tower => _tower;
}
