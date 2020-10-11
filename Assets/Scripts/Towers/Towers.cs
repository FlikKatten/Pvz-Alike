using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towers : MonoBehaviour
{
    public int price;
    public static GameObject tempTowerToMove;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (Cards.canMoveTower){tempTowerToMove = gameObject;}
    }
}
