
using UnityEngine;

public class PlayerIdleRunState : State<PlayerStates>
{
    private Rigidbody2D rb;
    private float direction = 0;
    private float Speed => ((PlayerCharacter)Owner).Speed;

    public override void Start(Character<PlayerStates> owner)
    {
        base.Start(owner);
        if (!Owner.TryGetComponent<Rigidbody2D>(out rb))
        {
            Debug.LogError("PlayerIdleRunState::Rigidbody2D not found on " + Owner.gameObject.name);
        }

    }

    public override void FixedUpdate(float delta)
    {
        rb.velocity = new Vector2(direction * Speed, rb.velocity.y);
    }

    public override void Update(float delta)
    {
        direction = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Owner.SetState(PlayerStates.JUMP);
        }
    }
}