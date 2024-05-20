using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    [SerializeField] private Provider _provider;
    private SpriteRenderer _color;

    private void Awake()
    {
        _color = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        try
        {
            _color.color = _provider.statStorage.colorStorage[Random.Range(0, _provider.statStorage.colorStorage.Length)];
            _provider.statStorage.SetValue();
            _provider.info.text = _provider.statStorage.value.ToString();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    private void OnCollisionStay2D(Collision2D other)
    {
        Debug.LogWarning("Stay");
    }
}
