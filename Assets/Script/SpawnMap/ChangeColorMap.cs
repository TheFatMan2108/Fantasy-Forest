using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.VersionControl;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChangeColorMap : MonoBehaviour
{
    [SerializeField] private GameObject listItem;
    [SerializeField] private Tilemap tilemap;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = Move.insta;
        Color color = gameManager.GetColor(gameManager.GetStatusSeasion());
        tilemap.color = color;
        Debug.Log("Mau: "+ gameManager.GetStatusSeasion());
        for(int i = 0;i< listItem.transform.childCount; i++)
        {
            listItem.transform.GetChild(i).GetComponent<SpriteRenderer>().color = color;
        }
    }

    // Update is called once per frame
  
}
