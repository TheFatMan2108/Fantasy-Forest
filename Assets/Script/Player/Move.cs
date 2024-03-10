using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float tocDo = 10f;
    [SerializeField] float nhay = 16f;
    [SerializeField] Animator animator;
    public static int jumpCount = 1;
    public static int jump;
    private float ngang = 0f;
    // Start is called before the first frame update
    void Start()
    {
        jump = jumpCount;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(ngang * tocDo, rb.velocity.y);
        flip();
        animator.SetFloat("Jump",rb.velocity.y);
        animator.SetBool("isChamDat", isChamDat.chamDat);
       
    }

    private void flip()
    {
        if (ngang!=0)
        {
            transform.localScale = new Vector3(ngang,transform.localScale.y);
        }
        else
        {
            animator.SetBool("isRun", false);
        }
    }

    public void onMove(InputAction.CallbackContext context)
    {
        ngang = context.ReadValue<Vector2>().x;
        animator.SetBool("isRun", true);
    }
    public void onJump(InputAction.CallbackContext context)
    {
        if (jump <= 0)
        {
            return;
        }
        switch (context.phase)
        {
            case InputActionPhase.Started:
                rb.velocity = new Vector2(rb.velocity.x,nhay);
                jump --;
                break;
            case InputActionPhase.Canceled: 
                break;
        }
    }

    
}
