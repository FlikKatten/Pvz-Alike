using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    private bool canCreate;

    public GameObject prefabTower01;

    void OnMouseDown()
    {
        print("clique");

        if(gameObject.tag == "CardTower01")
        {
            if (InterfaceController.moneyCount >= InterfaceController.towerValue01)
            {
                InterfaceController.moneyCount = InterfaceController.moneyCount - 25;
                GameConfig.currentTower = prefabTower01;
            }
        }

        if (gameObject.tag == "CardTower02")
        {
            if (InterfaceController.moneyCount >= InterfaceController.towerValue02)
            {
                InterfaceController.moneyCount = InterfaceController.moneyCount - 50;
            }
        }

        if (gameObject.tag == "CardTower03")
        {
            if (InterfaceController.moneyCount >= InterfaceController.towerValue03)
            {
                InterfaceController.moneyCount = InterfaceController.moneyCount - 75;
            }
        }

        if (gameObject.tag == "CardTower04")
        {
            if (InterfaceController.moneyCount >= InterfaceController.towerValue04)
            {
                InterfaceController.moneyCount = InterfaceController.moneyCount - 100;
            }
        }
    }
}
