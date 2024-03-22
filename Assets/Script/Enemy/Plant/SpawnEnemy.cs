using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject listPoints;
    [SerializeField] private GameObject Enemy;
    private GameManager gameManager;
    // Start is called before the first frame update
    private void Awake()
    {
        gameManager = Move.insta;
        Debug.Log("sl : "+ listPoints.transform.childCount);
    }
    void Start()
    {
        if (gameManager.GetScore() > 2000f)
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
