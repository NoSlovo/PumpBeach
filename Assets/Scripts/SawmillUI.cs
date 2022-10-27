using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class SawmillUI : MonoBehaviour
{
    [SerializeField] private SawmillTriger _sawmillTriger;
    [SerializeField] private TrigerSaw _trigerSaw;
    [SerializeField] private Text _text;

    private void OnEnable()
    {
        _trigerSaw.WoodInside += RefreshTextUI;
        _sawmillTriger.LogInsideColection += RefreshTextUI;
    }

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    private void Start()
    {
        RefreshTextUI();
    }


    private void RefreshTextUI()
    {
        _text.text = $"{_sawmillTriger.CountElement}/{_sawmillTriger.MaxLength}";
    }

    private void OnDisable()
    {
        _trigerSaw.WoodInside -= RefreshTextUI;
        _sawmillTriger.LogInsideColection -= RefreshTextUI;
    }
}
