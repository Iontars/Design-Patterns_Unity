#region Using
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
#endregion
/// <summary> Снимок </summary>
public class SnapShot
{
    public Vector3 CurrentPosition { get; private set; }

    public SnapShot( Vector3 inputPosition)
    {
        CurrentPosition = inputPosition;
    }
    
    public void CancelSnapShot()
    {
        
    }
}
