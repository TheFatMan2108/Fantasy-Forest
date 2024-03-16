using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    [SerializeField] GameObject coin;
    // Start is called before the first frame update
    void Start()
    {
        int soLuongCoin = UnityEngine.Random.Range(3,6);
        float spaceCoin = transform.position.x;
        for (int i = 0; i < soLuongCoin; i++)
        {
            Instantiate(coin, new Vector3(spaceCoin += 2, transform.position.y + 4f), Quaternion.identity, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
