using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMap : MonoBehaviour
{
    [SerializeField] private List<GameObject> mapSpawn;
    [SerializeField] private List<GameObject> maps ;
    [SerializeField] private Transform playerTranform;
    void Start()
    {
        Spawn5Map();
    }

    void Update()
    {
        SpawnMapToSpace();
        DeleteMapToSpace();
    }

    private void DeleteMapToSpace()
    {
        if (Vector2.Distance(playerTranform.transform.position,
            maps[0].transform.position) > 50f)
        {
            Destroy(maps[0]);
            maps.RemoveAt(0);

        }
    }

    private void SpawnMapToSpace()
    {
        if (Vector2.Distance(playerTranform.transform.position, 
            maps[maps.Count - 1].transform.Find("EndPoint").transform.position) < 30f)
        {
            Spawn5Map();
        }
    }

    private void Spawn5Map()
    {
        for (int i = 0; i < 5; i++)
        {
            int indexMap = UnityEngine.Random.Range(0, mapSpawn.Count);
            maps.Add(SpawnMaps(mapSpawn[indexMap]));
        }
    }
    private GameObject SpawnMaps(GameObject map)
    {
        float spaceMapX = UnityEngine.Random.Range(2,4);
        float spaceMapY = UnityEngine.Random.Range(-2,2);
        return Instantiate(map, maps[maps.Count - 1].transform.Find("EndPoint").
            transform.position+new Vector3(spaceMapX,spaceMapY)
            , Quaternion.identity, transform);
    }
}
