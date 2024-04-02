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
        huong = PlantAttack.huong;
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
        float x = speed * huong;
        if (Move.insta.GetScore()>3000)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(x, Mathf.Sin(transform.position.x)*9);
        }else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(x, GetComponent<Rigidbody2D>().velocity.y);
        }
       
       
    }
}
