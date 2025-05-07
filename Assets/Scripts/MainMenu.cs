using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("TotalCoin", 0);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("GameLv1");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void Credit()
    {
        SceneManager.LoadScene("Credit");
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
