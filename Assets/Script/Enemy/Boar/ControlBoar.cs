using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBoar : MonoBehaviour
{
    [SerializeField] private Transform postA;
    [SerializeField] private Transform postB;
    [SerializeField] private Animator animator;
    [SerializeField] private List<AudioClip> listSound;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float timer;
    [SerializeField] private float speed;
    [SerializeField] private bool isFaceToRight;
    private float yourTimer;
    private float yourSpeed;
    public static string KEY_ANIMATION_IDLE = "Boar_idle";
    public static string KEY_ANIMATION_WALK = "Boar_walk";
    void Start()
    {
        yourTimer = timer;
        yourSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        postA.position = new Vector3(postA.position.x,transform.position.y);
        postB.position = new Vector3(postB.position.x,transform.position.y);
        if (isFaceToRight)
        {
            if (Vector2.Distance(transform.position, postA.position) >=0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position,
                    postA.position, (yourSpeed+ SeePlayer.speed )* Time.deltaTime);
                animator.Play(KEY_ANIMATION_WALK);
            }
            else
            {
                yourTimer -= 1*Time.deltaTime;
                Debug.Log("TIME : " + yourTimer);
                if (yourTimer <= 0)
                {
                    isFaceToRight = !isFaceToRight;
                    transform.localScale = new Vector3((isFaceToRight?1:-1),transform.localScale.y);
                    yourTimer = timer;
                }
                animator.Play(KEY_ANIMATION_IDLE);
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, postB.position) >=0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position,
                    postB.position, (yourSpeed + SeePlayer.speed) * Time.deltaTime);
                animator.Play(KEY_ANIMATION_WALK);
            }
            else
            {
                yourTimer -= 1 * Time.deltaTime;
                Debug.Log("TIME : " + yourTimer);
                if (yourTimer <= 0)
                {
                    isFaceToRight = !isFaceToRight;
                    transform.localScale = new Vector3((isFaceToRight ? 1 : -1), transform.localScale.y);
                    yourTimer = timer;
                }
                animator.Play(KEY_ANIMATION_IDLE);
            }
        }
    }
    public void SoundIdle()
    {
        audioSource.clip = listSound[0];
        audioSource.Play();
    }
    public void SoundWalk()
    {
        audioSource.clip = listSound[1];
        audioSource.Play();
    }


}
