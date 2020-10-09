using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{

    void OnMouseDown()
    {
        if(gameObject.tag == "CardTower01")
        {
            if(InterfaceController.moneyCount <= 25)
            {
                InterfaceController.moneyCount = InterfaceController.moneyCount - 25;
            }
        }
        else if(gameObject.tag == "CardTower02")
        {
            if (InterfaceController.moneyCount <= 50)
            {
                InterfaceController.moneyCount = InterfaceController.moneyCount - 50;
            }
        }
        else if(gameObject.tag == "CardTower03")
        {
            if (InterfaceController.moneyCount <= 75)
            {
                InterfaceController.moneyCount = InterfaceController.moneyCount - 75;
            }
        }
        else if(gameObject.tag == "CardTower04")
        {
            if (InterfaceController.moneyCount <= 100)
            {
                InterfaceController.moneyCount = InterfaceController.moneyCount - 100;
            }
        }
    }
}
