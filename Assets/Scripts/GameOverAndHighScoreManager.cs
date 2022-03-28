using UnityEngine;
using UnityEngine.UI;

public class GameOverAndHighScoreManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverCanvas;

    [SerializeField]
    private GameObject yourScoreText;

    [SerializeField]
    private GameObject highScoreText;

    private void Start()
    {
        highScoreText.GetComponent<Text>().text = PlayerPrefs.GetInt("highScore").ToString();
    }

    public void GameOver()
    {
        yourScoreText.GetComponent<Text>().text = "Your score = " + PlayerPrefs.GetInt("score");

        if (PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", PlayerPrefs.GetInt("score"));
            highScoreText.GetComponent<Text>().text = PlayerPrefs.GetInt("highScore").ToString();
        }

        gameOverCanvas.SetActive(true);
    }
}
