using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepingPlace : MonoBehaviour
{
  [SerializeField] private Transform _entryPoint;

  public Transform EntryPoint => _entryPoint;
}
