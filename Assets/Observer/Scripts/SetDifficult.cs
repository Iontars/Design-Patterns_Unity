using System;
using UnityEngine;

public class SetDifficult : MonoBehaviour, IButtonPublisher
{
    public event Action setButtonPressed;

    public void PressButton() => Notify();

    public void Notify() => setButtonPressed?.Invoke();


}
