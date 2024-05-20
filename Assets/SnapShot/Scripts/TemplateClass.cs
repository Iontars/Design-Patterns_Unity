#region Using
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using TMPro;
#endregion

public class TemplateClass : MonoBehaviour
{
    private float _yAxis, _xAxis;
    [SerializeField]private float _speed = 300;
    private string _horizontal = "Horizontal";
    private string _vertical = "Vertical";

    private Vector3 _currentPosition;
    private readonly Stack<SnapShot> _snapStorage = new();
    private Rigidbody2D _rigidbody2D;
    private bool isCanSnap;

    private void Start()
    {
        SetCurrentPosition();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    public void SetCurrentPosition()
    {
        _currentPosition = transform.position;
    }

    public Vector3 GetCurrentPosition()
    {
        return _currentPosition;
    }

    public SnapShot GetSnapShot()
    {
        return new SnapShot(_currentPosition);
    }
    
    private void Update()
    {
        _xAxis = Input.GetAxis(_horizontal);
        _yAxis = Input.GetAxis(_vertical);
        Vector3 movement = new Vector3(_xAxis, _yAxis, 0) * (_speed * Time.deltaTime);
        _rigidbody2D.velocity = movement;
        if (_rigidbody2D.velocity.magnitude < 0.01f && !isCanSnap)
        {
            SetCurrentPosition();
            Storage.SnapStorage.Push(GetSnapShot());
            print(Storage.SnapStorage.Count);
            isCanSnap = true;
        }
        else if (_rigidbody2D.velocity.magnitude > 0.01f && isCanSnap)
        {
            isCanSnap = false;
        }
    }

    private IEnumerator GetSnapShot_C()
    {
        yield return new WaitForEndOfFrame();
    }
}
