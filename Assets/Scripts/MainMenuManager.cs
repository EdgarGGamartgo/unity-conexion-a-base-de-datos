using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetFloat("enemyMissilesSpeed", 1);
        PlayerPrefs.SetInt("roundNumber", 0);
        PlayerPrefs.SetInt("score", 0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("LevelScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
