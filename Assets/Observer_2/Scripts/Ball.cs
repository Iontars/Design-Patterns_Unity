using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    private Color _color;
    private Color _thisColor;
    private Ball _ball;

    public static Action<Ball> BallFallen;
    public Color ThisColor => _thisColor;

    private void Awake()
    {
        _ball = this;
        _color = new Color(Random.value, Random.value, Random.value);
        GetComponent<Renderer>().material.color = _color;
        _thisColor = GetComponent<Renderer>().material.color;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        BallFallen?.Invoke(_ball);
        Destroy(gameObject);
    }
}
