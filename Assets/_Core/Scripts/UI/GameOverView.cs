using System;
using UnityEngine;
using UnityEngine.UI;

public class GameOverView : MonoBehaviour
{
    public Button playAgainButton;

    private void Awake()
    {
        playAgainButton.onClick.AddListener(OnPlayAgainClick);
    }

    private void OnPlayAgainClick()
    {
        Game.Ins.ReloadScene();
    }
}
