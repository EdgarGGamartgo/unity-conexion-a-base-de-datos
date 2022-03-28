using UnityEngine;

public class EnemyMissileFlightController : MonoBehaviour
{
    private int index;
    private GameObject target;
    private float enemyMissileSpeed;

    private void Start()
    {
        if (GameStateManager.State != GameState.GameOver)
        {
            index = Random.Range(0, EnemyMissileManager.enemyTargetList.Length);
            target = EnemyMissileManager.enemyTargetList[index];
            enemyMissileSpeed = PlayerPrefs.GetFloat("enemyMissilesSpeed");
        }
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, enemyMissileSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, target.transform.position) <= 0.25)
            {
                if (target == null)
                {
                    Destroy(gameObject);
                }
                else
                {
                    Destroy(target);
                    Destroy(gameObject);
                }
            }            
        }
        else 
        {
            Destroy(gameObject);
        }      
    }
}
