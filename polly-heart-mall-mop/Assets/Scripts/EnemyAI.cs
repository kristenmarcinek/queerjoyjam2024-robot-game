using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;

    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;
    public enum enemyState
    {
        Patrol,
        Suspicious,
        Aggro
    }
    
    public Animator animator;

    public enemyState state;
    void Start()
    {
        state = enemyState.Patrol;
    }

    // Update is called once per frame
    void Update()
    {
        //switch statement which controls the state of the enemy
        switch (state)
        {
            case enemyState.Patrol:

                if (patrolDestination == 0)
                {
                    transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed *Time.deltaTime);
                    if (Vector2.Distance(transform.position, patrolPoints[0].position) <.2f)
                    {
                        transform.localScale = new Vector3(-1, 1, 1);

                        patrolDestination = 1;

                    }
                }

                if (patrolDestination == 1)
                {
                    transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
                    if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
                    {
                        transform.localScale = new Vector3(1, 1, 1);
                        patrolDestination = 0;

                    }
                }

                break;
            case enemyState.Suspicious:

                break;
            case enemyState.Aggro:

                break;


        }
     
    }

    public void NoticeSomething(Transform suspiciousObject)
    {
        state = enemyState.Suspicious;
        transform.position = Vector2.MoveTowards(transform.position, suspiciousObject.position, moveSpeed * Time.deltaTime);

    }
    private void SpotPlayer()
    {

    }

    /* ignore I realized this was all unecessary
    
        }*/

}
