using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    private HealthEnemy healthEnemy;
    private void Start()
    {
        healthEnemy = GetComponent<HealthEnemy>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BulletCoin"))
        {
            healthEnemy.TruMau(1f);
            if (healthEnemy.GetHealth() < 1)
            {
                Destroy(gameObject);
            }
        }
        if (collision.CompareTag("Meteorite"))
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Meteorite")) {
            Destroy(gameObject);
        }
    }
}

