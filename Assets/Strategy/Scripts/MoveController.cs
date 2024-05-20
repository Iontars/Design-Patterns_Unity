using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private float _speed = 10f;
    private float xAxis, yAxis;
    void Start()
    {
        
    }

    void Update()
    {
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");
        transform.Translate(xAxis * _speed * Time.deltaTime, yAxis * _speed * Time.deltaTime, 0);
    }
}
