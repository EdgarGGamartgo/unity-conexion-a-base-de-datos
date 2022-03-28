using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static int score;

    [SerializeField]
    private GameObject scoreText;

    private void Start()
    {
        score = PlayerPrefs.GetInt("score");
    }

    public static void UpdateScore(int value)
    {
        score += value;
        PlayerPrefs.SetInt("score", score);
    }

    private void FixedUpdate()
    {
        scoreText.GetComponent<Text>().text = PlayerPrefs.GetInt("score").ToString();
    }
}
