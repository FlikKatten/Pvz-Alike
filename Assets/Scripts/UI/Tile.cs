using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private bool isEmpty = true;

    void OnCollisionEnter()
    {
        isEmpty = false;
    }

    void OnCollisionExit()
    {
        isEmpty = true;
    }

    void OnMouseDown()
    {
        if (gameObject.tag == "Tile" && isEmpty)
        {
            //variavel hospeda valores de preço das torres

            if (Cards.canCreate)
            {
                int tempPrice = GameConfig.currentTower.GetComponent<Towers>().price;

                if (tempPrice <= InterfaceController.moneyCount)
                {
                    Instantiate(GameConfig.currentTower, transform.position, GameConfig.currentTower.transform.rotation);
                    InterfaceController.moneyCount -= tempPrice;
                    GameConfig.currentTower = null;
                }

                Cards.canCreate = false;
            }
            else if(Cards.canMoveTower)
            { 
                Vector3 tempPosition = gameObject.transform.position;
                Towers.tempTowerToMove.transform.position = tempPosition;
                Cards.canMoveTower = false;
                Towers.tempTowerToMove = null;
            }
        }
    }
}
