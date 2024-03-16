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
    [SerializeField] private MeshRenderer listMaterial;
    private float tocDoMap;
    public static int jumpCount = 1;
    public static int jump;
    private float ngang = 0f;
    // Start is called before the first frame update
    void Start()
    {
        jump = jumpCount;
        tocDoMap = 100f;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(tocDo, rb.velocity.y);
        animator.SetBool("isRun", true);
        animator.SetFloat("Jump", rb.velocity.y);
        animator.SetBool("isChamDat", isChamDat.chamDat);
        mapRun();
    }

    private void mapRun()
    {
/*        listMaterial.transform.position = new Vector3(
            transform.position.x
            , listMaterial.transform.position.y
            , listMaterial.transform.position.z);*/
        foreach (Material mr in listMaterial.materials)
        {
            mr.mainTextureOffset = new Vector2(transform.position.x / (tocDoMap -= 20), transform.position.y/100);
        }
        if (tocDoMap <= 20)
        {
            tocDoMap = 100f;
        }
    }

    private void Flip()
    {
        if (ngang != 0)
        {
            transform.localScale = new Vector3(ngang, transform.localScale.y);
        }
        else
        {
            animator.SetBool("isRun", false);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        ngang = context.ReadValue<Vector2>().x;
        animator.SetBool("isRun", true);
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (jump <= 0)
        {
            return;
        }
        switch (context.phase)
        {
            case InputActionPhase.Started:
                rb.velocity = new Vector2(rb.velocity.x, nhay);
                jump--;
                break;
            case InputActionPhase.Canceled:
                break;
        }
    }


}
