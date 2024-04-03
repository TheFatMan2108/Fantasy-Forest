using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    [SerializeField] private Transform pointSpawn;
    [SerializeField] private GameObject Meteorite;
    [SerializeField] private Image skillIcon;
    [SerializeField] private float timeForSencond;
    private float time;
  
    
    private int countMeteorite;
    // Start is called before the first frame update
    void Start()
    {
        countMeteorite = 3;
        time = 1/timeForSencond;
        skillIcon.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        skillIcon.fillAmount +=time* Time.deltaTime;
        if(Input.GetKeyUp(KeyCode.O)&& skillIcon.fillAmount>=1) 
        {
            for(int i = 0; i <countMeteorite; i++)
            {
                Instantiate(Meteorite,pointSpawn.position+new Vector3(i+3,0),Quaternion.identity);
            }
            skillIcon.fillAmount = 0;
        }
    }
}
