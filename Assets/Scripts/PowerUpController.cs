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

            if(gameObject.tag == "LaserController")
            {
                Destroy(c.gameObject);
                InterfaceController.scoreCount += 250;
                StartCoroutine(LaserControl());
            }
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

    IEnumerator LaserControl()
    {
        yield return new WaitForSeconds(0.5f);
        prefab.SetActive(false);
    }
}
