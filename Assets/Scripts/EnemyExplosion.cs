using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour
{
    public Collider2D collider2D;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float jumpForce = 2.5f;
    public int lifes = 2;
    public ParticleSystem explosionRef;
    public GameObject bloodSplash;
    public float blood;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") ||
            collision.transform.CompareTag("Shoot"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity =
                (Vector2.up * jumpForce);
            LoseLifeAndHit();
            CheckLife();
        }
    }

    public void LoseLifeAndHit()
    {
        lifes--;
        Instantiate(explosionRef, transform.position, Quaternion.identity);
        animator.Play("Hit");
    }

    public void CheckLife()
    {
        if (lifes == 0)
        {
            spriteRenderer.enabled = false;
            Instantiate(bloodSplash, new Vector3(transform.position.x,
                transform.position.y + blood), Quaternion.identity);
            Invoke("EnemyDie", 0.2f);
        }
    }

    public void EnemyDie()
    {
        Destroy(gameObject);
    }
}
