using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class PlantAttack : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform pointShoot;
    [SerializeField] private Animator animator;
    [SerializeField] private float timeShoot;
    private float timer;
    public static float huong;
    // Start is called before the first frame update
    void Start()
    {
        timer = timeShoot;
        transform.localScale = new Vector3(-1,transform.localScale.y) ;
        huong = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime*1;
        if (timer<=0)
        {
            animator.SetTrigger("Attack");
            timer = timeShoot;
        }
    }

    public void Attack()
    {
       Instantiate(Bullet,pointShoot.position,Quaternion.identity);
        GetComponent<AudioSource>().Play();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
    }
}
