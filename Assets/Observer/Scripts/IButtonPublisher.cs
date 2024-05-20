using System;
using UnityEngine;
/// <summary>
/// 
/// </summary>
public interface IButtonPublisher
{
    public abstract event Action setButtonPressed;
    public abstract void Notify();

}
