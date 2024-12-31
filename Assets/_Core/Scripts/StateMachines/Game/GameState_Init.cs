using Cysharp.Threading.Tasks;
using UnityEngine;

public class GameState_Init : StateBase<GameStates>
{
    public GameState_Init(GameStates _key) : base(_key)
    {
    }

    public override async UniTask EnterState()
    {
        Game.Ins.Init();
        LootManager.Ins.Init();
        Game.Ins.StartPlaying();
    }

    public override async UniTask ExitState()
    {
        
    }

    public override void UpdateState()
    {
        
    }
}
