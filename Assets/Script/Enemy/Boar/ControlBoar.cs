using System;
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
    [SerializeField] private LayerMask lmWall;
    [SerializeField] private LayerMask lmPlayer;
    private RaycastHit2D isChamTuong;
    private RaycastHit2D isSeelayer;
    private RaycastHit2D isChamDat;
    private float yourTimer;
    private float yourSpeed;
    private float angrySpeed;
    private float myScale;
    private int huong;
    public static string KEY_ANIMATION_IDLE = "Boar_idle";
    public static string KEY_ANIMATION_WALK = "Boar_walk";
    void Start()
    {
        yourTimer = timer;
        yourSpeed = speed;
        angrySpeed = 0f;
    }
    private void FixedUpdate()
    {

        vungNhin();
    }
    // Update is called once per frame
    void Update()
    {
        WalkToPoint();
       
    }

    private void walkToEndMap()
    {
        // làm di chuyển không cần điểm đích
        if (!isChamTuong&&isChamDat)
        {
            // được đi

        }
        else
        {
            // dừng lại đổi hướng
        }
    }

    private void WalkToPoint()
    {
        postA.position = new Vector3(postA.position.x, transform.position.y);
        postB.position = new Vector3(postB.position.x, transform.position.y);
        if (isFaceToRight)
        {
            if (Vector2.Distance(transform.position, postA.position) >= 0.1f && !isChamTuong && isChamDat)
            {
                transform.position = Vector2.MoveTowards(transform.position,
                    postA.position, (yourSpeed + angrySpeed) * Time.deltaTime);
                animator.Play(KEY_ANIMATION_WALK);
            }
            else
            {
                yourTimer -= 1 * Time.deltaTime;
                if (yourTimer <= 0)
                {
                    isFaceToRight = !isFaceToRight;
                    myScale = isFaceToRight ? 1f : -1f;
                    Debug.Log("rightface: " + myScale);
                    transform.localScale = new Vector3(myScale, transform.localScale.y);
                    yourTimer = timer;
                }
                animator.Play(KEY_ANIMATION_IDLE);
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, postB.position) >= 0.1f && !isChamTuong)
            {
                transform.position = Vector2.MoveTowards(transform.position,
                    postB.position, (yourSpeed + angrySpeed) * Time.deltaTime);
                animator.Play(KEY_ANIMATION_WALK);
            }
            else
            {
                yourTimer -= 1 * Time.deltaTime;
                if (yourTimer <= 0)
                {
                    isFaceToRight = !isFaceToRight;
                    myScale = isFaceToRight ? 1f : -1f;
                    transform.localScale = new Vector3(myScale, transform.localScale.y);
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

    private void vungNhin ()
    {
        isChamTuong = Physics2D.Raycast(transform.position+new Vector3(0f,2f),Vector2.right* myScale, 1.3f,lmWall);
        isChamDat = Physics2D.Raycast(transform.position + new Vector3(2f * myScale,1f), Vector2.down, 1.5f,lmWall);
        isSeelayer = Physics2D.Raycast(transform.position+Vector3.up,Vector2.right* myScale, 8f,lmPlayer);

        if (isChamTuong)
        {
            Debug.DrawRay(transform.position + new Vector3(0f, 2f), new Vector3(isChamTuong.distance * myScale, 0f),Color.red);
        }
        else
        {
            Debug.DrawRay(transform.position + new Vector3(0f, 2f), new Vector3(1.3f * myScale, 0f), Color.green);
        }
        if (isSeelayer)
        {
            Debug.DrawRay(transform.position + Vector3.up, new Vector3(isSeelayer.distance * myScale, 0f), Color.red);
            angrySpeed = 10f;
        }
        else
        {
            Debug.DrawRay(transform.position + Vector3.up, new Vector3(10f * myScale, 0f), Color.green);
            angrySpeed = 0f;
        }
        if (isChamDat)
        {
            Debug.DrawRay(transform.position + new Vector3(1f * myScale, 1f), new Vector3(0f, -isChamDat.distance), Color.red);
        }
        else
        {
            Debug.DrawRay(transform.position + new Vector3(1f * myScale, 1f), new Vector3( 0f, -2f), Color.green);
        }
    }
    
}
