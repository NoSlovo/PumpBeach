using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SleepWolk : MonoBehaviour
{
   [SerializeField] private Bonfire _bonfire;

   private protected abstract void Sllep(Enemy enemy);
}
