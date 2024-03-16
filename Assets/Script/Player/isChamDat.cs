using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class isChamDat : MonoBehaviour
{
   public static bool chamDat = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Dat"))
        {
            chamDat = true;
            Move.jump = Move.jumpCount;
            Debug.Log("Dang cham dat");
        }
        if (collision.CompareTag("DeadPoint"))
        {
            // * Thêm màn hình dead scene khi rảnh *
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Coin"))
        {
            chamDat = true;
        }
    }
 
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Dat"))
        {
            chamDat = !chamDat ;
            Debug.Log("Dang ko cham dat");
        }
    }
}
