using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    private bool canCreate;

    public GameObject prefabTower01, prefabTower02, prefabTower03, prefabTower04;

    void OnMouseDown()
    {
        switch (gameObject.tag)
        {
            case "CardTower01":
                GameConfig.currentTower = prefabTower01;
                break;
            case "CardTower02":
                GameConfig.currentTower = prefabTower02;
                break;
            case "CardTower03":
                GameConfig.currentTower = prefabTower03;
                break;
            case "CardTower04":
                GameConfig.currentTower = prefabTower04;
                break;
        }
    }
}
