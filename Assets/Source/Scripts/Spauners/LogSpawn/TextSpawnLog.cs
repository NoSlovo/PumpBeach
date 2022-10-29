using System;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextSpawnLog : MonoBehaviour
{
   [SerializeField] private LogSpawner _logSpawner;
   [SerializeField] private Text _textUI;

   private int _maxLog = 28;
   private const string _full = "Full";

   private void OnEnable()
   {
      _logSpawner.SpawnLog += PassNumber;
   }

   private void Awake()
   {
      _textUI = GetComponent<Text>();
   }

   private void PassNumber(int number)
   {
      if (_maxLog  == _logSpawner.CountColection)
      {
         _textUI.text = _full;
      }
      else
      {
         _textUI.text = $"{number}/{_maxLog}";
      }
      
   }

   private void OnDisable()
   {
      _logSpawner.SpawnLog -= PassNumber;
   }
}
