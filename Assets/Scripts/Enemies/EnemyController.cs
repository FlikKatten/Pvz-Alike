using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed, destroyTime, playerZone, bulletLoopTime, coroutineTime;
    public int damage;
    public Material[] materials;
    public Renderer ghostRenderer;
    public GameObject bulletPrefab, dropPosition, explosionPrefab;

    private bool canWalk = true;

    void Update()
    {
        float currentSpeed = canWalk ? speed : 0;

        if (canWalk)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        /*retirando pontos do jogador quando algum 
        inimigo chegue até sua zona após o tabuleiro*/
        if(transform.position.x >= playerZone)
        {
            Destroy(gameObject, destroyTime);
            InterfaceController.scoreCount -= damage;
        }
    }

    void OnTriggerEnter(Collider c)
    {
        switch (c.gameObject.tag)
        {
            case "Tower":
                switch (gameObject.tag)
                {
                    case "Enemy01":
                        ghostRenderer.material = materials[1];
                        break;
                    case "Enemy02":
                        Destroy(c.gameObject);
                        /*retirando score do jogador quando este perde suas torres*/
                        InterfaceController.scoreCount -= damage;
                        break;
                    case "Enemy03":
                        RandonAttack(c.gameObject);
                        StartCoroutine(CoinCatch(coroutineTime));
                        break;
                    case "Enemy04":
                        StartCoroutine(FlyAttack(coroutineTime, c.gameObject));
                        break;
                }
                break;
            case "Shield":
                switch (gameObject.tag)
                {
                    case "Enemy01":
                        ghostRenderer.material = materials[1];
                        break;
                    case "Enemy02":
                        Destroy(c.gameObject);
                        break;
                    case "Enemy03":
                        RandonAttack(c.gameObject);
                        StartCoroutine(CoinCatch(coroutineTime));
                        break;
                }
                break;
            case "CannonBall":
                if (gameObject.tag == "Enemy01")
                {
                    ghostRenderer.material = materials[1];
                }
                break;
        }
    }

    void OnTriggerExit(Collider c)
    {
        if(gameObject.tag == "Enemy01"){ghostRenderer.material = materials[0];}
    }

    IEnumerator FlyAttack(float f, GameObject gb)
    {
        canWalk = false;

        for (int i = 0; i <= bulletLoopTime; i++)
        {
            Instantiate(bulletPrefab, dropPosition.transform.position, transform.rotation);
            yield return new WaitForSeconds(f);
        }

        Destroy(gb);
        canWalk = true;
    }

    IEnumerator Attack(float f, GameObject gb)
    {

        canWalk = false;
        yield return new WaitForSeconds(f);
        Destroy(gb);
        InterfaceController.scoreCount -= damage;
        canWalk = true;
    }

    void RandonAttack(GameObject gb)
    {
        canWalk = false;
        explosionPrefab.SetActive(true);

        int i = Random.Range(0, 2);

        switch (i)
        {
            case 1:
                Cards.blockCard = true;
                break;
            case 2:
                Coin.fakeCoin = true;
                break;
        }

        Destroy(gb);
    }

    IEnumerator CoinCatch(float f)
    {
        yield return new WaitForSeconds(f);

        explosionPrefab.SetActive(false);
        canWalk = true;
    }
}
