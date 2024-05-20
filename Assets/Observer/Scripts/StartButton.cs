using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void StartLevel() => SceneManager.LoadScene("Game");
}
