using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public float speed, distance, attackRange;
    public static GameObject currentTarget;

    private Vector3 attackPosition;
    private AudioSource audioS;

    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, currentTarget.transform.position);

        if (distance < attackRange)
        {
            attackPosition = currentTarget.transform.position;

            transform.position = Vector3.MoveTowards(transform.position,
                attackPosition, speed * Time.deltaTime);
        }

        if(currentTarget == null)
        {
            Destroy(gameObject);
            CannonController.targetFind = false;
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Enemy02" || c.gameObject.tag == "Enemy03" || c.gameObject.tag == "Cop")
        {
            if(c.gameObject.tag == "Cop")
            {
                Destroy(c.gameObject.transform.parent.gameObject);
            }

            Destroy(c.gameObject);
            currentTarget = null;
            CannonController.targetFind = false;

            audioS.Play();
            InterfaceController.scoreCount += 25;
            Destroy(gameObject);
        }
    }
}
