using System.Collections;
using UnityEngine;

public class EnemyMissileManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyMissileListExample;
    private GameObject[] enemyMissileList;

    public static GameObject[] enemyTargetList;

    private float enemyMissileSpeedFloat;

    private void Start()
    {
        enemyMissileSpeedFloat = PlayerPrefs.GetFloat("enemyMissilesSpeed");
        PlayerPrefs.SetFloat("enemyMissilesSpeed", 0.25f + enemyMissileSpeedFloat);
    }

    public void EnemyMissilesWave()
    { 
        enemyMissileList = new GameObject[enemyMissileListExample.Length];

        for (int i = 0; i < enemyMissileListExample.Length; i++)
        {
            enemyMissileList[i] = Instantiate(enemyMissileListExample[i], transform) as GameObject;
        }
    }

    public void UpdateEnemyTargetList()
    {
        enemyTargetList = GameObject.FindGameObjectsWithTag("Target");
    }

    public void CheckEnemyMissilesAmount()
    {
        StartCoroutine(UpdateEnemyMissilesList());
    }

    IEnumerator UpdateEnemyMissilesList()
    {
        while (GameStateManager.State != GameState.GameOver)
        {
            yield return new WaitForSeconds(1);
            enemyMissileList = GameObject.FindGameObjectsWithTag("EnemyMissile");

            if (enemyMissileList.Length < 1)
            {
                yield return new WaitForSeconds(2);
                if (GameStateManager.State != GameState.GameOver)
                    GameStateManager.Instance.UpdateGameState(GameState.Summary);
                break;
            }
        }
    }
}
