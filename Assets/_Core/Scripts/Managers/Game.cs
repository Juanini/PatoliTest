using System;
using Obvious.Soap;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Game : Singleton<Game>
{
    public LevelConfigSO activeLevelConfig;
    public IntVariable levelCoinsVar;

    public void Awake()
    {
        Init();
    }

    private void Init()
    {
        levelCoinsVar.OnValueChanged += OnCoinsValueChanged;
    }

    private void OnCoinsValueChanged(int coins)
    {
        if (levelCoinsVar.Value >= activeLevelConfig.coinsToCompleteLevel)
        {
            LevelCompleted();
        }
    }

    private void LevelCompleted()
    {
        UIManager.Ins.ShowGameOver();
    }
    
    // * =====================================================================================================================================
    // * 

    private void OnDestroy()
    {
        levelCoinsVar.OnValueChanged -= OnCoinsValueChanged;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(Constants.SCENE_GAME);
    }
}
