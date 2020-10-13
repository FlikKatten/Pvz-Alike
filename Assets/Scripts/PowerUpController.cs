using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public GameObject prefab;
    public AudioClip[] clips;

    private AudioSource audioS;

    void Start(){audioS = GetComponent<AudioSource>();}

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Enemy01" || c.gameObject.tag == "Enemy02" 
            || c.gameObject.tag == "Enemy03")
        {
            prefab.SetActive(true);

            if(gameObject.tag == "LaserController")
            {
                PlaySound(1);
                Destroy(c.gameObject);
                InterfaceController.scoreCount += 25;
                StartCoroutine(LaserControl());
            }
            else{PlaySound(0);}
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "Enemy01" || c.gameObject.tag == "Enemy02" 
            || c.gameObject.tag == "Enemy03")
        {prefab.SetActive(false);}
    }

    IEnumerator LaserControl() 
    {
        yield return new WaitForSeconds(0.5f);
        prefab.SetActive(false);
    }

    void PlaySound(int a)
    {
        audioS.clip = clips[a];
        audioS.Play();
    }
}
