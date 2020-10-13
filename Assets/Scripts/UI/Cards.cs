using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cards : MonoBehaviour
{
    public GameObject prefabTower01, prefabTower02, prefabTower03, prefabTower04;
    public static bool canMoveTower, canCreate, blockCard;
    public float coroutineTime;
    public AudioClip[] clips;
    
    private AudioSource audioS;

    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (blockCard)
        {
            int i = Random.Range(0, 4);

            switch (i)
            {
                case 1:
                    if (gameObject.tag == "CardTower01")
                    {
                        StartCoroutine(ChangeTag(coroutineTime, gameObject));
                    }
                    break;
                case 2:
                    if (gameObject.tag == "CardTower02")
                    {
                        StartCoroutine(ChangeTag(coroutineTime, gameObject));
                    }
                    break;
                case 3:
                    if (gameObject.tag == "CardTower03")
                    {
                        StartCoroutine(ChangeTag(coroutineTime, gameObject));
                    }
                    break;
                case 4:
                    if (gameObject.tag == "CardTower04")
                    {
                        StartCoroutine(ChangeTag(coroutineTime, gameObject));
                    }
                    break;
            }
        }
    }

    IEnumerator ChangeTag(float f, GameObject gb)
    {
        /*esta funcao muda a tag da carta 
        impossibilitando que o jogador a selecione*/

        Image image= this.GetComponent<Image>();
        var tempColor = image.color;
        tempColor.a = 0.5f;
        image.color = tempColor;

        string originalTag = gameObject.tag;
        gameObject.tag = "Untagged";

        yield return new WaitForSeconds(f);

        gameObject.tag = originalTag;

        tempColor.a = 1f;
        image.color = tempColor;

        blockCard = false;
    }

    void OnMouseDown()
    {
        /*verificando a carta selecionada e atribuindo
        um prefab para a variavel hospedeira*/
        switch (gameObject.tag)
        {
            case "CardTower01":
                PlaySound(0);
                GameConfig.currentTower = prefabTower01;
                canCreate = true;
                break;
            case "CardTower02":
                PlaySound(0);
                GameConfig.currentTower = prefabTower02;
                canCreate = true;
                break;
            case "CardTower03":
                PlaySound(0);
                GameConfig.currentTower = prefabTower03;
                canCreate = true;
                break;
            case "CardTower04":
                PlaySound(0);
                GameConfig.currentTower = prefabTower04;
                canCreate = true;
                break;
            case "MoveTower":
                GameConfig.currentTower = null;
                canMoveTower = true;
                break;
            case "Untagged":
                PlaySound(1);
                break;
        }
    }

    void PlaySound(int a)
    {
        audioS.clip = clips[a];
        audioS.Play();
    }
}
