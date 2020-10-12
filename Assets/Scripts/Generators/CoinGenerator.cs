using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public GameObject coinPrefab;
    public float firstInvoke, loopInvoke;

    void Start()
    {
        InvokeRepeating("CoinMaker", firstInvoke, loopInvoke);
    }

    void CoinMaker()
    {
        Instantiate(coinPrefab, transform.position, transform.rotation);
    }
}
