using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed, destroyTime, playerZone, bulletLoopTime, coroutineTime;
    public int damage;
    public Material[] materials;
    public Renderer ghostRenderer;
    public GameObject bulletPrefab;

    private bool canWalk = true;

    void Start()
    {
        ghostRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        float currentSpeed = canWalk ? speed : 0;

        if (canWalk)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        //retirando pontos do jogador quando algum inimigo chegue até sua zona após o tabuleiro
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
                        //ghostRenderer.material = materials[1];
                        break;
                    case "Enemy02":
                        Destroy(c.gameObject);
                        break;
                    case "Enemy03":
                        StartCoroutine(Attack(coroutineTime));
                        Destroy(c.gameObject);
                        break;
                    case "Enemy04":
                        StartCoroutine(FlyAttack(bulletPrefab, coroutineTime, bulletLoopTime));
                        Destroy(c.gameObject);
                        break;
                }
                break;
            case "Shield":
                switch (gameObject.tag)
                {
                    case "Enemy01":
                        //ghostRenderer.material = materials[1];
                        break;
                    case "Enemy02":
                        Destroy(c.gameObject);
                        break;
                    case "Enemy03":
                        StartCoroutine(Attack(coroutineTime));
                        Destroy(c.gameObject);
                        break;
                }
                break;
            case "Laser":
                Destroy(gameObject, destroyTime);
                break;
            case "CannonBall":
                if (gameObject.tag == "Enemy01")
                {
                    //ghostRenderer.material = materials[1];
                }
                break;
        }
    }

    void OnTriggerExit(Collider c)
    {
        if(gameObject.tag == "Enemy01")
        {
            //ghostRenderer.material = materials[0];
        }
    }

    IEnumerator FlyAttack(GameObject gb, float f, float l)
    {
        canWalk = false;
        for (int i = 0; i <= l; i++)
        {
            Instantiate(gb, transform.position, transform.rotation);

            yield return new WaitForSeconds(f);

            StartCoroutine(FlyAttack(gb, f, l));
        }

        canWalk = true;
    }

    IEnumerator Attack(float f)
    {
        canWalk = false;
        yield return new WaitForSeconds(f);
        canWalk = true;
    }
}
