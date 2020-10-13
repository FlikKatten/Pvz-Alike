using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towers : MonoBehaviour
{
    public int price;
    public static GameObject tempTowerToMove;

    private AudioSource audioS;

    void Start(){audioS = GetComponent<AudioSource>();}

    void OnMouseDown()
    {
        if (Cards.canMoveTower)
        {
            audioS.Play();
            tempTowerToMove = gameObject;
            Cards.canCreate = false;
        }
    }
}
