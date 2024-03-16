using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DestroyCoin : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TMP_Text textScore;
    [SerializeField] private TMP_Text textHighScore;
    private int tempScore = 0;
    private void Awake()
    {
        textScore.SetText("Score " + tempScore.ToString("n0"));
        textHighScore.SetText("High Score " + gameManager.GetHighScore().ToString("n0"));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Coin"))
        {
            tempScore += 20;
            gameManager.SetScore(tempScore);
            gameManager.SetHighScore(tempScore);
            textScore.SetText("Score " + tempScore.ToString("n0"));
            textHighScore.SetText("High Score " + gameManager.GetHighScore().ToString("n0"));
            Destroy(collision.gameObject);
        }
    }
}
