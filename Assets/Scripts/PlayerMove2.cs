using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove2 : MonoBehaviour
{
    public float maxSpeed = 10f;
    bool facingRight = true;
    public Rigidbody2D rb;
    public float delayShoot = .1f;
    bool isFacingLeft;
    private bool isShooting;
    public Animator animator;
    private bool canDoubleJump;
    public float jumpSpeed = 3;
    public float doubleJumpSpeed = 2.5f;

    [SerializeField]
    Transform shootSpawnPos;

    [SerializeField]
    GameObject shoot;

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (CheckGround.isGrounded)
            {
                canDoubleJump = true;
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            }
            else
            {
                if (Input.GetKeyDown("space"))
                {
                    if (canDoubleJump)
                    {
                        animator.SetBool("DoubleJump", true);
                        rb.velocity = new Vector2(rb.velocity.x, doubleJumpSpeed);
                        canDoubleJump = false;
                    }
                }
            }
        }

        if (CheckGround.isGrounded == false)
        {
            print(true);
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }

        if (CheckGround.isGrounded == true)
        {
            print(false);
            animator.SetBool("Jump", false);
            animator.SetBool("Falling", false);
            animator.SetBool("DoubleJump", false);
        }

        if (rb.velocity.y < 0)
        {
            animator.SetBool("Falling", true);
        }
        else if (rb.velocity.y > 0)
        {
            animator.SetBool("Falling", false);
        }
    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(move));
        rb.velocity = new Vector2(move * maxSpeed * Time.deltaTime, rb.velocity.y);
        if (move > 0 && !facingRight)
        {
            isFacingLeft = false;
            Flip();
        }   
        else if (move < 0 && facingRight)
        {
            isFacingLeft = true;
            Flip();
        }

        if (Input.GetKeyDown("z"))
        {
            if (isShooting) return;
            isShooting = true;
            GameObject b = Instantiate(shoot);
            b.transform.position = shootSpawnPos.transform.position;
            b.GetComponent<ShootPlayer>().StartShoot(isFacingLeft);
            Invoke("ResetShoot", delayShoot);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void ResetShoot()
    {
        isShooting = false;
        animator.Play("Idle");

    }
}
