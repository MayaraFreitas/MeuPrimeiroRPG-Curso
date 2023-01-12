using Assets.Scripts.Constants;
using Assets.Scripts.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;

    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        OnMove();
        OnRun();
    }

    #region Movement
    void OnMove()
    {
        // Controlar tipo de animação
        if (player.direction.sqrMagnitude > 0)
        {
            if (player.isRolling)
            {
                anim.SetTrigger(PlayerConstants.IsRoll);
            }
            else
            {
                SetAnimation(PlayerTransition.Walk);
            }
        }
        else
        {
            SetAnimation(PlayerTransition.Idle);
        }

        // Controlar direção da animação
        if (player.direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }


        // Controlar Cutting
        if (player.isCutting)
        {
            SetAnimation(PlayerTransition.Cut);
        }
    }

    void OnRun()
    {
        if (player.isRunning)
        {
            SetAnimation(PlayerTransition.Run);
        }
    }

    private void SetAnimation(PlayerTransition playerTransition) => anim.SetInteger(PlayerConstants.Transition, (int)playerTransition);

    #endregion Movement
}
