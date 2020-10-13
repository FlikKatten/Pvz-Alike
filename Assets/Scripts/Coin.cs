using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float lifeTime, coroutineTime;
    public int coinValue;
    public Material[] materials;

    private Renderer coinRenderer;

    public static bool fakeCoin;

    void Start()
    {
        coinRenderer = GetComponent<Renderer>();
        StartCoroutine(DestroyCoin(lifeTime));
    }

    void Update()
    {
        if (fakeCoin)
        {
            StartCoroutine(FakeSystem(coroutineTime));
        }
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
        if (fakeCoin)
        {
            InterfaceController.moneyCount -= coinValue;
        }
        else
        {
            InterfaceController.moneyCount += coinValue;
        }

        Destroy(gameObject);
    }

    IEnumerator FakeSystem(float f)
    {
        coinRenderer.material = materials[1];

        yield return new WaitForSeconds(f);

        coinRenderer.material = materials[0];

        fakeCoin = false;
    }
}
