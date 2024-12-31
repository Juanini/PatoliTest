using UnityEngine;

public enum GameStates
{
    Init = 0,
    Playing,
    LevelCompleted
}
public class GameState : StateMachine<GameStates>
{
    public async void Init()
    {
        AddState(GameStates.Init,gameObject.AddComponent<GameState_Init>(),this);
        AddState(GameStates.Playing,gameObject.AddComponent<GameState_Playing>(),this);
        AddState(GameStates.LevelCompleted,gameObject.AddComponent<GameState_LevelComplete>(),this);
        
        await EnterInitialState(States[GameStates.Init]);
    }
}
