using System;
using Obvious.Soap;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string PLAYER_ANIM_IDLE = "PlayerIdle";
    private const string PLAYER_ANIM_WALK = "PlayerWalk";
    
    [SerializeField] private Vector2Variable playerVelocity;
    private int facingDirection = 1;

    public void Init()
    {
        playerVelocity.OnValueChanged += HandleVelocityChange;
    }

    private void HandleVelocityChange(Vector2 velocity)
    {
        PlayAnim(velocity.sqrMagnitude > 0.01f ? PLAYER_ANIM_WALK : PLAYER_ANIM_IDLE);
        CheckFacingDirection(velocity);
    }

    private void PlayAnim(string animName)
    {
        _animator.Play(animName);
    }

    private void CheckFacingDirection(Vector2 velocity)
    {
        facingDirection = velocity.x switch
        {
            > 0f => 1,
            < 0f => -1,
            _ => facingDirection
        };

        transform.localScale = new Vector3(facingDirection, 1f, 1f);
    }
    
    // * =====================================================================================================================================

    private void OnDestroy()
    {
        playerVelocity.OnValueChanged -= HandleVelocityChange;
    }
}
