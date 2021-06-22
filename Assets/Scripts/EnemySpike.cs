using UnityEngine;

public class EnemySpike : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.transform.GetChild(2).gameObject.SetActive(true);
            Destroy(collision.gameObject, 0.3f);
            collision.transform.GetComponent<PlayerRespawn>().PlayerDead();
        }
    }
}