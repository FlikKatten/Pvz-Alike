using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public GameObject prefab;

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Enemy01"
            || c.gameObject.tag == "Enemy02" || c.gameObject.tag == "Enemy03")
        {
            prefab.SetActive(true);
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "Enemy01"
            || c.gameObject.tag == "Enemy02" || c.gameObject.tag == "Enemy03")
        {
            prefab.SetActive(false);
        }
    }
}
