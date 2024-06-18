using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayNight : MonoBehaviour
{
    [SerializeField] private float timeDayNight;
    private float light;
    private Light2D light2D;
    private bool isDay;
    private Color thisColor;
    // Start is called before the first frame update
    void Start()
    {
        light2D = GetComponent<Light2D>();
        isDay = true;
        thisColor = light2D.color;
        light = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDay)
        {
            light -= (timeDayNight/60) * Time.deltaTime;
            if (light < -0.5000)
            {
                isDay = !isDay;
            }
        }
        else
        {
            light += (timeDayNight/60) * Time.deltaTime;
            if (light > 1.000)
            {
                isDay = !isDay;
            }
        }

        light2D.intensity = light;
    }
}
