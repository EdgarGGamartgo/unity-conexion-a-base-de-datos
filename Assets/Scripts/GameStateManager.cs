using System.Collections;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    public static GameState State;

    private bool gameOverFlag;

    [SerializeField]
    private EnemyMissileManager enemyMissileManager;

    [SerializeField]
    private SummaryManager summaryManager;

    [SerializeField]
    private GameOverAndHighScoreManager gameOverAndHighScoreManager;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateGameState(GameState.LevelStart);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.LevelStart:
                LevelStartState();
                break;
            case GameState.EnemyMissileWave:
                EnemyMissileWaveState();
                break;
            case GameState.Summary:
                SummaryState();
                break;
            case GameState.GameOver:
                GameOverState();
                break;
        }
    }

    private void FixedUpdate()
    {
        enemyMissileManager.UpdateEnemyTargetList();

        if (EnemyMissileManager.enemyTargetList.Length < 1 && gameOverFlag == false)
        {
            gameOverFlag = true;
            UpdateGameState(GameState.GameOver);
        }

    }
    private void GameOverState()
    {
        gameOverAndHighScoreManager.GameOver();
    }

    private void SummaryState()
    {
        summaryManager.StartSummary();
    }

    private void EnemyMissileWaveState()
    {
        StartCoroutine(EnemyMissileWaves());
    }

    private void LevelStartState()
    {
        // LevelScene Starts in this state
    }

    IEnumerator EnemyMissileWaves()
    {
        while (State == GameState.EnemyMissileWave)
        {
            for (int i = 0; i <= 4; i++)
            {
                enemyMissileManager.EnemyMissilesWave();
                yield return new WaitForSeconds(5);
            }
            break;
        }
        if (State != GameState.GameOver)
            enemyMissileManager.CheckEnemyMissilesAmount();
    }
}

public enum GameState
{
    LevelStart,
    EnemyMissileWave,
    Summary,
    GameOver
}

