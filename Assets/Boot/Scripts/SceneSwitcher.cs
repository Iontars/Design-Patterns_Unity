using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// </summary>
public class SceneSwitcher : MonoBehaviour
{
    public void SwitchScene(string value)
    {
        SceneManager.LoadScene(value);
    }
}
