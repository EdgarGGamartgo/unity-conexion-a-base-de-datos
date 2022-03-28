using UnityEngine;

public class PlayerMissileFlightController : MonoBehaviour
{
    [SerializeField]
    private GameObject playerMissileExplosionPrefab;
    private Ray target;

    private void Awake()
    {
        target = PlayerController.MousePosition();
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.origin, 7.5f * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.origin) < 0.1f)
        {
            GameObject playerMissileExplosion = Instantiate(playerMissileExplosionPrefab, target.origin, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
