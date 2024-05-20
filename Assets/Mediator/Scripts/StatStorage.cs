using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatStorage : MonoBehaviour
{
    public Color[] colorStorage;
    public int value;

    public void SetValue()
    {
        value = Random.Range(0, 101);
    }
    
}
