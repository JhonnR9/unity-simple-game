using System;
using UnityEngine;

public class PlayerJumpState : State<PlayerStates>
{
    float jumpForce = 7;
    Rigidbody2D rb;

    public override void Start(Character<PlayerStates> owner)
    {
        base.Start(owner);
        if (!Owner.TryGetComponent<Rigidbody2D>(out rb))
        {
            Debug.LogError("PlayerJumpState::Rigidbody2D not found on " + Owner.gameObject.name);
        }
    }
    public override void Enter()
    {
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }


    public override void FixedUpdate(float delta)
    {
        rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, 0.02f), rb.velocity.y);

    }

    public override void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "ground")
        {
            Owner.SetState(PlayerStates.IDLE_RUN);
        }
    }
}
