using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SummaryManager : MonoBehaviour
{
    private GameObject[] citiesLeft;
    private GameObject[] playerMissilesLeft;
    [SerializeField]
    private GameObject summaryCanvas;
    [SerializeField]
    private GameObject roundNumberCompletedText;
    [SerializeField]
    private GameObject citiesAndMissilesSavedText;

    public void StartSummary()
    {
        if (GameStateManager.State != GameState.GameOver)
        {
            playerMissilesLeft = GameObject.FindGameObjectsWithTag("PlayerMissileInStorage");

            citiesLeft = GameObject.FindGameObjectsWithTag("City");

            roundNumberCompletedText.GetComponent<Text>().text = "Round #" + PlayerPrefs.GetInt("roundNumber").ToString() + " Completed!";

            citiesAndMissilesSavedText.GetComponent<Text>().text = "Cities saved = " + citiesLeft.Length + " x 100 " +
                "\n Missiles saved = " + playerMissilesLeft.Length + " x 10";

            for (int i = 0; i < citiesLeft.Length; i++)
            {
                ScoreManager.UpdateScore(100);
            }

            for (int i = 0; i < playerMissilesLeft.Length; i++)
            {
                ScoreManager.UpdateScore(10);
            }

            summaryCanvas.SetActive(true);

            Invoke("NextRound", 4);
        }
        else
        {
            GameStateManager.Instance.UpdateGameState(GameState.GameOver);
        }
    }

    private void NextRound()
    {
        if (GameStateManager.State != GameState.GameOver)
            SceneManager.LoadScene("LevelScene");
        else
            GameStateManager.Instance.UpdateGameState(GameState.GameOver);
    }
}
