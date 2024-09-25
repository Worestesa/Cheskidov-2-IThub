using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerColor : MonoBehaviour
{
    [SerializeField] private List<SpriteRenderer> groundTiles;
    [SerializeField]private PlayerControler playerControler;
    [SerializeField]
    private void Update()
    {
        CheckTilesCollor();
    }
    private void CheckTilesCollor()
    {
        for (int i = 0; i < groundTiles.Count; i++)
        {
            if(groundTiles[i].color != playerControler.accentColor)
            {
                return;
            }
            
        }
        Debug.Log("WIN");
    }

}
