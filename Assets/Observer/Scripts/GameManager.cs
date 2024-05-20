using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public enum Difficult{ easy, normal, hard }

public class GameManager : MonoBehaviour, IObserver
{
    [Header("Components Stuff")][Space(3)]
    public List<Text> currentText;

    private GameObject[] _setButtons;
    private List<IButtonPublisher> _publisherButtons;
    private Difficult _difficult_e;
    private byte _counter = default;

    void IObserver.Subscribe(IButtonPublisher value) => value.setButtonPressed += ChooseDifficult;

    void IObserver.UnSubscribe(IButtonPublisher value) => value.setButtonPressed -= ChooseDifficult;

    private void Awake()
    {
        _setButtons = GameObject.FindGameObjectsWithTag("SetButton");
        _publisherButtons = new();
        for (int i = 0; i < _setButtons.Length; i++)
        {
            _publisherButtons.Add(_setButtons[i].GetComponent<SetDifficult>());
        }
    }

    private void ChooseDifficult()
    {
        if (++_counter > Convert.ToInt32(Difficult.hard)) _counter = default; // последнее значение enum, есть его размер
        switch (_counter)
        {
            case 0: _difficult_e = Difficult.easy; break;
            case 1: _difficult_e = Difficult.normal; break;
            case 2: _difficult_e = Difficult.hard; break;
        }

        foreach (var item in currentText)
        {
            gameObject.GetComponent<GameManager>()?.DisplayInfoOnTEXT(item, _difficult_e);
        }
    }

    public void DisplayInfoOnTEXT<T>(Text textComponent, T enumValue ) => textComponent.text = enumValue.ToString();

    private void OnEnable()
    {
        foreach (var item in _publisherButtons)
        {
            ((IObserver)gameObject.GetComponent<GameManager>()).Subscribe(item);
        }
    }

    private void OnDisable()
    {
        foreach (var item in _publisherButtons)
        {
            ((IObserver)gameObject.GetComponent<GameManager>()).UnSubscribe(item);
        }
    }
}
