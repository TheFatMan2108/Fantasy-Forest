using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
