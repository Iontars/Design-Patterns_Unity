using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Bullet : MonoBehaviour, IFireing
{
    protected abstract float Damage { get;  set; }
    protected abstract float Speed { get;  set; }
    protected abstract float Mass { get;  set; }

    protected Rigidbody2D rb;
    protected abstract SpriteRenderer GoColor { get;  set; }
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke(nameof(DestroyBullet), 4);
    }

    public virtual void DestroyBullet(float value)
    {
        if (gameObject != null)
        {
            Destroy(gameObject, value);
        }
    }
    
    public virtual void DestroyBullet()
    {
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnBecameInvisible()
    {
        DestroyBullet(0.3f);
    }
    
    protected virtual void OnMove()
    {
        rb.velocity = Vector2.up * Speed;
    }

    private void FixedUpdate()
    {
        OnMove();
    }
}
