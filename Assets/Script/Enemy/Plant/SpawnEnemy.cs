using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject listPoints;
    [SerializeField] private GameObject Enemy;
   [SerializeField] private int diem ;
    // Start is called before the first frame update
    private void Awake()
    {
        diem = Move.insta.GetScore();
    }
    void Start()
    {
        if (diem > 2000f)
        {

            int indexSpawn = Random.Range(0, listPoints.transform.childCount);
            Instantiate(Enemy, listPoints.transform.GetChild(indexSpawn).transform.position, Quaternion.identity,transform);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
