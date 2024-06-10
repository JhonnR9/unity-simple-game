using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character<PlayerStates>
{
    [SerializeField] private float speed = 20f;
    public float Speed { get { return speed; } set { speed = value; } }
    void Start()
    {
        AddState(PlayerStates.IDLE_RUN, new PlayerIdleRunState());
        AddState(PlayerStates.JUMP, new PlayerJumpState());

        SetState(PlayerStates.IDLE_RUN);
    }

}
