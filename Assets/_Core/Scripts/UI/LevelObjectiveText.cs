using System;
using UnityEngine;
using Obvious.Soap;
using TMPro;

public class LevelObjectiveText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private IntVariable levelCoinsVar;

    private void Awake()
    {
        levelCoinsVar.OnValueChanged += OnCoinsValueChanged;
        SetText();
    }

    private void OnCoinsValueChanged(int obj)
    {
        SetText();
    }

    private void SetText()
    {
        text.text = levelCoinsVar.Value + " / " + Game.Ins.activeLevelConfig.coinsToCompleteLevel;
    }

    private void OnDestroy()
    {
        levelCoinsVar.OnValueChanged += OnCoinsValueChanged;
    }
}
