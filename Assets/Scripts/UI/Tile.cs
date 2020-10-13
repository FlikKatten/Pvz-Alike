using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public AudioClip[] clips;

    private AudioSource audioS;
    private bool isEmpty = true;

    void Start(){audioS = GetComponent<AudioSource>();}

    void OnCollisionEnter(Collision c)
    {
        isEmpty = false;
        if(c.gameObject.tag == "Bullet"){Destroy(c.gameObject);}
    }

    void OnCollisionExit(){isEmpty = true;}

    void OnMouseDown()
    {
        if (gameObject.tag == "Tile" && isEmpty)
        {
            if (Cards.canCreate)
            {
                //variavel hospeda valores de preço das torres
                int tempPrice = GameConfig.currentTower.GetComponent<Towers>().price;

                if (tempPrice <= InterfaceController.moneyCount)
                {
                    Instantiate(GameConfig.currentTower, transform.position, 
                        GameConfig.currentTower.transform.rotation);
                    InterfaceController.moneyCount -= tempPrice;
                    GameConfig.currentTower = null;
                    PlaySound(0);
                }

                Cards.canCreate = false;
            }
            else if(Cards.canMoveTower)
            { 
                Vector3 tempPosition = gameObject.transform.position;
                Towers.tempTowerToMove.transform.position = tempPosition;
                Cards.canMoveTower = false;
                Towers.tempTowerToMove = null;
                PlaySound(0);
            }
            else{PlaySound(1);}
        }
    }

    void PlaySound(int a)
    {
        audioS.clip = clips[a];
        audioS.Play();
    }
}
