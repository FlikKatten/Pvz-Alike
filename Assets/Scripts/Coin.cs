using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float lifeTime;
    public int coinValue;

    void Start()
    {
        StartCoroutine(DestroyCoin(lifeTime));
    }

    IEnumerator DestroyCoin(float f)
    {
        yield return new WaitForSeconds(f);

        DestroyReact();
    }

    void OnMouseDown()
    {
        DestroyReact();
    }

    void DestroyReact()
    {
        InterfaceController.moneyCount += coinValue;
        Destroy(gameObject);
    }
}
