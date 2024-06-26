using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    EnemyStats enemy;
    Transform player;
    //GameObject play;

    Vector2 knockbackVelocity;
    float knockbackDuration;
    
    void Start()
    {
        enemy = GetComponent<EnemyStats>();
        //play = GameObject.FindGameObjectWithTag("Player").transform;
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    
    void Update()
    {
        if(knockbackDuration > 0)
        {
            transform.position += (Vector3)knockbackVelocity * Time.deltaTime;
            knockbackDuration -= Time.deltaTime;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemy.currentMoveSpeed * Time.deltaTime);
        }
    }

    public void Knockback(Vector2 velocity, float duration)
    {
        if (knockbackDuration > 0) return;
        knockbackVelocity = velocity;
        knockbackDuration = duration;
    }
}
