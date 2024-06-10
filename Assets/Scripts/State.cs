
using UnityEngine;

public abstract class State<T>
{
    Character<T> owner;
    protected Character<T> Owner => owner;

    public virtual void Start(Character<T> owner)
    {
        this.owner = owner;
    }
    public virtual void Enter() { }
    public virtual void Update(float delta) { }
    public virtual void FixedUpdate(float delta) { }
    public virtual void Exit() { }
    public virtual void OnCollisionEnter2D(Collision2D coll) { }
}