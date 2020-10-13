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
    public AudioClip[] clips;

    private bool canWalk = true;
    private AudioSource audioS;

    void Start()
    {
        audioS = GetComponent<AudioSource>();

        if (gameObject.tag == "Enemy01")
        {
            ghostRenderer.material = materials[0];
        }
    }

    void Update()
    {
        float currentSpeed = canWalk ? speed : 0;

        if (canWalk){transform.Translate(Vector3.forward * speed * Time.deltaTime);}

        /*retirando pontos do jogador quando algum 
        inimigo chegue até sua zona após o tabuleiro*/
        if(transform.position.x == playerZone)
        {
            PlaySound(0);
            InterfaceController.scoreCount -= damage;
            Destroy(gameObject, destroyTime);
        }
    }

    void OnTriggerEnter(Collider c)
    {
        switch (c.gameObject.tag)
        {
            case "Tower":
                switch (gameObject.tag)
                {
                    case "Enemy02":
                        Destroy(c.gameObject);
                        PlaySound(2);
                        /*retirando score do jogador quando este perde suas torres*/
                        InterfaceController.scoreCount -= damage;
                        break;
                    case "Enemy03":
                        canWalk = false;
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
                    case "Enemy02":
                        Destroy(c.gameObject);
                        break;
                    case "Enemy03":
                        RandonAttack(c.gameObject);
                        StartCoroutine(CoinCatch(coroutineTime));
                        break;
                }
                break;
        }
    }

    void OnTriggerStay(Collider c)
    {
        if (c.gameObject.tag == "Tower" || c.gameObject.tag == "Shield")
        {
            if (gameObject.tag == "Enemy01")
            {
                ghostRenderer.material = materials[1];
            }
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (gameObject.tag == "Enemy01")
        {
            if (c.gameObject.tag == "Tower")
            {
                Attack(c.gameObject);
            }

            ghostRenderer.material = materials[0];
        }
    }

    IEnumerator FlyAttack(float f, GameObject gb)
    {
        canWalk = false;

        for (int i = 0; i <= bulletLoopTime; i++)
        {
            Instantiate(bulletPrefab, dropPosition.transform.position, transform.rotation);
            PlaySound(1);
            yield return new WaitForSeconds(f);
        }

        Destroy(gb);
        canWalk = true;
    }

    void Attack(GameObject gb)
    {
        PlaySound(2);
        Destroy(gb);
        InterfaceController.scoreCount -= damage;
    }

    void RandonAttack(GameObject gb)
    {
        canWalk = false;
        explosionPrefab.SetActive(true);

        int i = Random.Range(0, 2);

        //este inimigo possui uma variedade de 'ataques'
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

    void PlaySound(int a)
    {
        audioS.clip = clips[a];
        audioS.Play();
    }

    void OnDestroy()
    {
        if(gameObject == CannonBall.currentTarget)
        {
            CannonBall.currentTarget = null;
            CannonController.targetFind = false;
        }
    }
}
