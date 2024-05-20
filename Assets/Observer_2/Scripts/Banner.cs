using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

public class Banner : MonoBehaviour, IObserver2
{
    [SerializeField] private Text _text;
    private int _counter;
    
    private void OnEnable()
    {
        Ball.BallFallen += DoAction;
    }
    private void OnDisable()
    {
        Ball.BallFallen -= DoAction;
    }

    public void DoAction(object obj)
    {
        Ball ball = obj as Ball;
        if (ball != null) GetComponent<Image>().color = ball.ThisColor;
        _text.text = (++_counter).ToString();
    }
}
