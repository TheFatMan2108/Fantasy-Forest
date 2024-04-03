using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteAttack : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject firer;
    [SerializeField] private Transform pointSpawn;
    [SerializeField] private AudioClip endSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x+ speed * Time.fixedDeltaTime,
            transform.position.y+(speed * -1)*Time.fixedDeltaTime);
    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dat"))
        {
            StartCoroutine(RunThis());
        }
    }
    IEnumerator RunThis()
    {
        yield return SpawnFire();
        yield return new WaitForSeconds(0.3f);
        yield return DestroyThis();
    }
    IEnumerator DestroyThis()
    {
        Destroy(gameObject);
        yield return null;
    }
    IEnumerator SpawnFire()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<AudioSource>().clip = endSound;
        GetComponent<AudioSource>().Play();
        for (int i = 0; i < 2; i++)
        {
            Instantiate(firer, new Vector3(pointSpawn.position.x + i * 3, Mathf.Sin(pointSpawn.position.x )), Quaternion.identity);
        }
        yield return null;
    }

}
