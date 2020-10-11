using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public GameObject shield;

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Enemy01"
            || c.gameObject.tag == "Enemy02" || c.gameObject.tag == "Enemy03")
        {
            shield.SetActive(true);
        }
    }

    void onTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "Enemy01"
            || c.gameObject.tag == "Enemy02" || c.gameObject.tag == "Enemy03")
        {
            shield.SetActive(false);
        }
    }
}
