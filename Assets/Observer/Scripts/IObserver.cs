using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System;

/// <summary>
/// 
/// </summary>
public interface IObserver
{
    public abstract void Subscribe(IButtonPublisher action);
    public abstract void UnSubscribe(IButtonPublisher action);
}
