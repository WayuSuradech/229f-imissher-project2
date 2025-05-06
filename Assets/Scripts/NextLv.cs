using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLv : MonoBehaviour
{
    public void LoadNextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameLv2");
    }
    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // หรือ Application.Quit();
    }
}
