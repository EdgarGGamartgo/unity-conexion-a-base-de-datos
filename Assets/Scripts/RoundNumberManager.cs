using UnityEngine;
using UnityEngine.UI;

public class RoundNumberManager : MonoBehaviour
{
    private int roundNumberInt;
    [SerializeField]
    private GameObject roundNumberText;

    private void Awake()
    {
        roundNumberInt = PlayerPrefs.GetInt("roundNumber");
        PlayerPrefs.SetInt("roundNumber", roundNumberInt + 1);
        roundNumberText.GetComponent<Text>().text = "Round #" + PlayerPrefs.GetInt("roundNumber").ToString();
    }
}
