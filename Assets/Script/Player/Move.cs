using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float nhay = 16f;
    [SerializeField] private MeshRenderer listMaterial;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject tochToPlay;
    [SerializeField] private SettingMusicAndSound setting;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform pointShoot;
    [SerializeField] private Slider sliderHeart;
    [SerializeField] private Slider sliderStamina;
    private float tocDo = 0;
    private float tocDoMap;
    public static int jumpCount = 2;
    public static int jump;
    private float ngang = 0f;
    private RunAudio audioManager;
    public static GameManager insta;
    private Animator animator;
    private bool isAttack;
    private float countDown;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
    }
    void Start()
    {
        jump = jumpCount;
        tocDoMap = 100f;
        audioManager = RunAudio.instance;
        insta = gameManager;
        sliderHeart.maxValue = gameManager.GetMaxHeart();
        sliderHeart.minValue = gameManager.GetMinHeart();
        sliderStamina.maxValue = gameManager.GetTimCountMax();
        sliderStamina.minValue = gameManager.GetTimCountMin();
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(tocDo, rb.velocity.y);
        MapRun();
    }
    private void Update()
    {
        animator.SetFloat("Jump", rb.velocity.y);
        animator.SetBool("isChamDat", isChamDat.chamDat);
        sliderHeart.value = gameManager.GetHeart();
        countDown += Time.deltaTime;
        sliderStamina.value = countDown;
        if (countDown>=gameManager.GetTimCountMax())
        {
            isAttack=true;
            countDown=3;
        }
    }
    private void MapRun()
    {
        if (listMaterial == null)
        {
            return;
        }
        foreach (Material mr in listMaterial.materials)
        {
            mr.mainTextureOffset = new Vector2(transform.position.x / (tocDoMap -= 20), transform.position.y / 100);
        }
        if (tocDoMap <= 20)
        {
            tocDoMap = 100f;
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
                if (!gameManager.GetPlaying())
                {
                    gameManager.SetPLaying(true);
                    tocDo = 7f;
                    animator.SetBool("isRun", true);
                    GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                    if (tochToPlay != null)
                    {
                        tochToPlay.SetActive(false);
                    }
                }
                else
                {
                    rb.velocity = new Vector2(rb.velocity.x, nhay);
                    jump--;
                    PlayJump();
                }

                break;
            case InputActionPhase.Canceled:
                break;
        }
    }

    public float GetSpeed()
    {
        return tocDo;
    }
    public void SetSpeed(float nSpeed)
    {
        tocDo = nSpeed;
    }
    public void PlayRun()
    {
        if (audioManager == null)
        {
            Debug.Log("Bị null");
            return;
        }
        // chưa có sound chạy
    }
    public void StopRun()
    {
        if (audioManager == null)
        {
            Debug.Log("Bị null");
            return;
        }
        audioManager.StopSound();
    }
    public void PlayJump()
    {
        if (audioManager == null)
        {
            Debug.Log("Bị null");
            return;
        }
        audioManager.PlaySound("Jump");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") ||
            collision.gameObject.CompareTag("Plant") ||
            collision.gameObject.CompareTag("Boar"))
        {
            float i = gameManager.GetHeart();
            if (i <= gameManager.GetMinHeart())
            {
                setting.OnMenuDead();
            }
            else
            {
                i -= 1;
                gameManager.SetHeart(i);
            }
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (setting == null)
        {
            return;
        }
        if (collision.CompareTag("DeadPoint"))
        {
            setting.OnMenuDead();
        }
        
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                if (gameManager.GetScore() >= 200f&&isAttack)
                {
                    int i = gameManager.GetScore();
                    gameManager.SetScore((i -= 200));
                    Instantiate(bullet, pointShoot.position, Quaternion.identity);
                    isAttack = false;
                    countDown = 0;
                }
                break;
            case InputActionPhase.Canceled:
                break;
        }
    }
}
