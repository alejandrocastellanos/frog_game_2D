using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : MonoBehaviour
{
    private float waitedTime;
    public float waitTimeAttack = 3;
    public Animator animator;
    public GameObject bulletPrefab;
    public Transform launchSpawnPoint;

    private void Start()
    {
        waitedTime = waitTimeAttack;
    }

    private void Update()
    {
        if (waitedTime <= 0)
        {
            waitedTime = waitTimeAttack;
            Invoke("LaunchBullet", 0.5f);
            animator.Play("Attack");
        }
        else
        {
            waitedTime -= Time.deltaTime;
        }
    }

    private void LaunchBullet()
    {
        GameObject newBullet;
        newBullet = Instantiate(bulletPrefab, launchSpawnPoint.position,
            launchSpawnPoint.rotation);
    }
}
