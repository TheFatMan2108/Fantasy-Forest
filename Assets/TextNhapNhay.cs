using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextNhapNhay : MonoBehaviour
{
    [SerializeField] private TMP_Text message;
    private float time;
    private float fontSize;
    private bool tangGiam = true;
    void Start()
    {
        time = 1;

    }
    private void Update()
    {
        
        if (tangGiam)
        {
            time += 0.4f * Time.deltaTime;
            if (time>=1f)
            {
                tangGiam = !tangGiam;
            }
        }
        else 
        {
            time -= 0.4f * Time.deltaTime;
            if (time<=0.5)
            {
                tangGiam = !tangGiam;
            }
        }
        fontSize = 143*time;
        message.fontSize = fontSize;
        Debug.Log(time+" time");
       
        
    }
}
