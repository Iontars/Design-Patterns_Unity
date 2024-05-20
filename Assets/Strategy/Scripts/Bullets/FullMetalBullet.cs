using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullMetalBullet : Bullet
{
    protected override float Damage { get; set; }
    protected override float Speed { get; set; }
    protected override float Mass { get; set; }
    protected override SpriteRenderer GoColor { get;  set; }

    private void Awake()
    {
        Speed = 30;
        GoColor = GetComponent<SpriteRenderer>();
        GoColor.color = Color.red;
    }
    
    protected override void OnMove()
    {
        rb.AddForce(Vector2.up * (Speed * Time.deltaTime), ForceMode2D.Impulse);
    }
    
    private void Update()
    {
        OnMove();
    }
}

