using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform targetPlayer;
    private int speed = 1;
    private int life = 2;
    private float stoppingDistance = 1.5f;
    private float chaseDistance = 10.7f;
    private float shootDistance = 5.3f;

    // Start is called before the first frame update
    void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
        LifeDamage();
    }

    void LifeDamage()
    {
        //Get the state of the left shift button
        float damage = Input.GetAxis("Fire3");

        //Condition to deduct life points if the player press the button from a certain distance
        if (damage == 1 && Vector2.Distance(transform.position, targetPlayer.position) <= shootDistance)
        {
            life--;

            if (life <= 0)
                Destroy(gameObject);
        }
    }

    void ChasePlayer()
    {
        //Condition to the enemy start chase the player from a certain distance
        if (Vector2.Distance(transform.position, targetPlayer.position) < chaseDistance)
        {
            //Condition to the enemy stop by a certain distance from player
            if (Vector2.Distance(transform.position, targetPlayer.position) > stoppingDistance)
                transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);
        }
    }
}
