using System;
using Cysharp.Threading.Tasks;
using Obvious.Soap;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Game : Singleton<Game>
{
    public GameState gameState;
    public LevelConfigSO activeLevelConfig;
    public IntVariable levelCoinsVar;

    public void Awake()
    {
        gameState.Init();
    }

    public void Init()
    {
        levelCoinsVar.OnValueChanged += OnCoinsValueChanged;
    }
    
    public void StartPlaying()
    {
        gameState.TransitionToState(GameStates.Playing);
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
        gameState.TransitionToState(GameStates.LevelCompleted);
    }
    
    public void ReloadScene()
    {
        SceneManager.LoadScene(Constants.SCENE_GAME);
    }
    
    // * =====================================================================================================================================
    // * 

    private void OnDestroy()
    {
        levelCoinsVar.OnValueChanged -= OnCoinsValueChanged;
    }

    
}
