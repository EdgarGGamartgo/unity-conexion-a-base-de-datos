using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject hill1;
    [SerializeField]
    private GameObject hill2;
    [SerializeField]
    private GameObject hill3;

    [SerializeField]
    private PlayerMissileAmountManager playerMissileAmountManagerHill1;
    [SerializeField]
    private PlayerMissileAmountManager playerMissileAmountManagerHill2;
    [SerializeField]
    private PlayerMissileAmountManager playerMissileAmountManagerHill3;

    [SerializeField]
    private GameObject playerMissilePrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("MenuScene");

         if (GameStateManager.State == GameState.EnemyMissileWave)
        {
            if (Input.GetKeyDown(KeyCode.A))
                FireMissileFromHill('A');


            if (Input.GetKeyDown(KeyCode.S))
                FireMissileFromHill('S');


            if (Input.GetKeyDown(KeyCode.D))
                FireMissileFromHill('D');
        }
    }

    private void FireMissileFromHill(char input)
    {
        if (input == 'A' && hill1 != null) 
        {
            if (playerMissileAmountManagerHill1.missileList.Length != 0)
            {
                GameObject playerMissileHill1 = Instantiate(playerMissilePrefab, hill1.transform.position, Quaternion.identity);
                playerMissileAmountManagerHill1.RemoveMissile();
            }
        }

        if (input == 'S' && hill2 != null)
        {
            if (playerMissileAmountManagerHill2.missileList.Length != 0)
            {
                GameObject playerMissileHill2 = Instantiate(playerMissilePrefab, hill2.transform.position, Quaternion.identity);
                playerMissileAmountManagerHill2.RemoveMissile();
            }
        }

        if (input == 'D' & hill3 != null)
        {
            if (playerMissileAmountManagerHill3.missileList.Length != 0)
            {
                GameObject playerMissileHill3 = Instantiate(playerMissilePrefab, hill3.transform.position, Quaternion.identity);
                playerMissileAmountManagerHill3.RemoveMissile();
            }
        }
    }

    public static Ray MousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return ray;
    }
}
