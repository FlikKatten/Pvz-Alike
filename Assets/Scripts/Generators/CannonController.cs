using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject cannonBallPrefab;
    public static bool targetFind;

    void OnTriggerEnter(Collider c)
    {
        if (!targetFind)
        {
            if (c.gameObject.tag == "Enemy02" || c.gameObject.tag == "Enemy03" 
                || c.gameObject.tag == "Cop")
            {
                targetFind = true;
                SpawnCannonBall(cannonBallPrefab, c.gameObject);
            }
        }
    }

    void SpawnCannonBall(GameObject gb1, GameObject gb2)
    {
        Instantiate(gb1, transform.position, transform.rotation);
        CannonBall.currentTarget = gb2;
    }
}
