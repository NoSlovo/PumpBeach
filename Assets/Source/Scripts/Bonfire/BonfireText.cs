using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class BonfireText : MonoBehaviour
{
   [SerializeField] private Bonfire _bonfire;
   [SerializeField] private Text _textUI;

   private void OnEnable()
   {
      _bonfire.LogInside += RefreshTextUI;
   }

   private void Awake()
   {
      _textUI = GetComponent<Text>();
   }

   private void RefreshTextUI()
   {
      if (_bonfire.maxLogs == 0)
      {
         _textUI.text =$"{_bonfire.activeLogsCount}/{_bonfire.MaxActiveElemnt}";
      }
      else
      {
         _textUI.text = $"{_bonfire.activeLogsCount}/{_bonfire.maxLogs}";    
      }
   }
   

   private void OnDisable()
   {
      _bonfire.LogInside -= RefreshTextUI;
   }
}
