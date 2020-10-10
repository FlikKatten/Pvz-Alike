using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private bool isEmpty = true;

    void Start()
    {

    }

    void Update()
    {
        //RaycastHit3D hit = Physics.Raycast(transform.position, Vector3.up, 0.1f, LayerMask.GetMask("Tower"));
        //isEmpty = hit.collider == null;
    }

    void OnMouseDown()
    {
        int tempPrice = GameConfig.currentTower.GetComponent<Towers>().price;

        if (gameObject.tag == "Tile" && tempPrice <= InterfaceController.moneyCount)
        {
            Instantiate(GameConfig.currentTower, transform.position, transform.rotation);
            InterfaceController.moneyCount = InterfaceController.moneyCount - tempPrice;
            GameConfig.currentTower = null;
        }
    }
}
