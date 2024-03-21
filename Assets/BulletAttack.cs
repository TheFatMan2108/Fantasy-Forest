using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAttack : MonoBehaviour
{
    [SerializeField] private float speedShoot;
    [SerializeField] private float timeDestroy;
    private float speed;
    private float huong;
    // Start is called before the first frame update
    private void Start()
    {
        // sau này làm quái quay theo người chơi
        huong = -1f;
        //
        speed = speedShoot;
        Destroy(gameObject, timeDestroy);
    }
    // Update is called once per frame
    void Update()
    {
      
    }
    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(speed * huong, GetComponent<Rigidbody2D>().velocity.y));
    }
}
