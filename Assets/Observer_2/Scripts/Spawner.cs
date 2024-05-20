using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class Spawner : MonoBehaviour, IObserver2
{
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
        ball.gameObject.name = "Ball";
        Instantiate(ball.gameObject, gameObject.transform.position, Quaternion.identity);
    }
}
