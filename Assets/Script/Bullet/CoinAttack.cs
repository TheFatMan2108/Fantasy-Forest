using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAttack : MonoBehaviour
{
    [SerializeField] private float tocDo;
    [SerializeField] private float huong;
    [SerializeField] private float time;
    [SerializeField] private List<AudioClip> sounds;
    void Start()
    {
        Destroy(gameObject, time);
        GetComponent<AudioSource>().clip = sounds[0];
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(tocDo * huong, GetComponent<Rigidbody2D>().velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")&&!collision.CompareTag("Coin"))
        {
            GetComponent<AudioSource>().clip = sounds[1];
            GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }

    }
}
