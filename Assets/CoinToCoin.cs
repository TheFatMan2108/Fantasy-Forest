using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinToCoin : MonoBehaviour
{
    // sinh ra đẻ tránh coin gần nhau
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.transform.CompareTag("Dat"))
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
 
}
