using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    public GameObject prefabTower01, prefabTower02, prefabTower03, prefabTower04;
    public static bool canMoveTower, canCreate;

    void OnMouseDown()
    {
        //verificando a carta selecionada e atribuindo um prefab para a variavel hospedeira
        switch (gameObject.tag)
        {
            case "CardTower01":
                GameConfig.currentTower = prefabTower01;
                canCreate = true;
                break;
            case "CardTower02":
                GameConfig.currentTower = prefabTower02;
                canCreate = true;
                break;
            case "CardTower03":
                GameConfig.currentTower = prefabTower03;
                canCreate = true;
                break;
            case "CardTower04":
                GameConfig.currentTower = prefabTower04;
                canCreate = true;
                break;
            case "MoveTower":
                GameConfig.currentTower = null;
                canMoveTower = true;
                break;
        }
    }
}
