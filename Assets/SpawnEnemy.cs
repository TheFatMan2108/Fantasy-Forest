using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private List<Transform> listSpawnPoint;
    [SerializeField] private GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        int indexSpawn = Random.Range(0,listSpawnPoint.Count);
        Instantiate(Enemy, listSpawnPoint[indexSpawn].position,Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
