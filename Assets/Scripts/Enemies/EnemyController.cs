using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed, destroyTime, playerZone;
    public int damage;
    public Material[] materials;
    public Renderer ghostRenderer;

    private bool canWalk = true;

    void Start()
    {
        ghostRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
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
                        ghostRenderer.material = materials[1];
                        break;
                    case "Enemy02":
                        Destroy(c);
                        break;
                    case "Enemy03":
                        print(gameObject.tag);
                        break;
                    case "Enemy04":
                        print(gameObject.tag);
                        break;
                }
                break;
            case "Shield":
                if(gameObject.tag == "Enemy01")
                {
                    ghostRenderer.material = materials[1];
                }
                else
                {
                    canWalk = false;
                }

                break;
            case "Laser":
                Destroy(gameObject);
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
        if(gameObject.tag == "Enemy01")
        {
            ghostRenderer.material = materials[0];
        }
    }
}
