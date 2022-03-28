using UnityEngine;

public class PlayerMissileExplosionController : MonoBehaviour
{
    private void Start()
    {
        Invoke("DestroyAfter2Seconds", 2);
    }

    private void DestroyAfter2Seconds()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyMissile")
        {
            Destroy(collision.gameObject);
            ScoreManager.UpdateScore(20);
        }
    }
}
