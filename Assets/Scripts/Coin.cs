using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float lifeTime, fakeSystemTime, coroutineTime;
    public int coinValue;
    public Material[] materials;
    public static bool fakeCoin;

    private Renderer coinRenderer;
    private AudioSource audioS;

    void Start()
    {
        audioS = GetComponent<AudioSource>();
        coinRenderer = GetComponent<Renderer>();
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {if (fakeCoin){StartCoroutine(FakeSystem(fakeSystemTime));}}

    void OnDestroy()
    {
        if (fakeCoin){InterfaceController.moneyCount -= coinValue;}
        else{InterfaceController.moneyCount += coinValue;}
    }

    IEnumerator DestroyCoin(float f)
    {
        audioS.Play();

        yield return new WaitForSeconds(f);

        Destroy(gameObject);
    }

    void OnMouseDown(){ StartCoroutine(DestroyCoin(coroutineTime)); }

    IEnumerator FakeSystem(float f)
    {
        coinRenderer.material = materials[1];

        yield return new WaitForSeconds(f);

        coinRenderer.material = materials[0];

        fakeCoin = false;
    }
}
