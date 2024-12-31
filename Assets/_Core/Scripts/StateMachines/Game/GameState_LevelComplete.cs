using Cysharp.Threading.Tasks;
using UnityEngine;

public class GameState_LevelComplete : StateBase<GameStates>
{
    public GameState_LevelComplete(GameStates _key) : base(_key)
    {
    }

    public override async UniTask EnterState()
    {
        await UniTask.Delay(500);
        UIManager.Ins.ShowGameOver();
    }

    public override async UniTask ExitState()
    {
        
    }

    public override void UpdateState()
    {
        
    }
}
