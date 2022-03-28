using UnityEngine;

public class LevelStartStateCanvas : MonoBehaviour
{
    [SerializeField]
    private GameObject levelStartCanvas;

    private void Start()
    {
        Invoke("LevelStartStateCanvasInit",2);
    }

    private void LevelStartStateCanvasInit()
    {
        levelStartCanvas.SetActive(false);
        GameStateManager.Instance.UpdateGameState(GameState.EnemyMissileWave);
    }
}
