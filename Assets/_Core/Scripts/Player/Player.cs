using System;
using Obvious.Soap;
using UnityEngine;

public class Player: MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerAnim _playerAnim;

    [Header("SO")]
    [SerializeField] private Vector2Variable playerVelocity;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _playerMovement.Init();
        _playerAnim.Init();
    }
}
