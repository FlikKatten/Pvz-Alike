using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject[] enemiesPrefab;
    public float coroutineMaxTime;

    void Start()
    {
        StartCoroutine(SpawnEnemies(coroutineMaxTime));
    }

    IEnumerator SpawnEnemies(float f)
    {
        yield return new WaitForSeconds(5f);
        yield return new WaitForSeconds(Random.Range(0, f));

        Instantiate(enemiesPrefab[Random.Range(0, enemiesPrefab.Length)], transform.position, transform.rotation);

        StartCoroutine(SpawnEnemies(f));
    }
}
