using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public float aggroMeter;
    public float aggroMaximum;

    enum enemyState
    {
        Patrol,
        Suspicious,
        Aggro
    }


    private enemyState state;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        state = enemyState.Patrol;

        switch (state)
        {
            case enemyState.Patrol:
                break;
            case enemyState.Suspicious:
                break;
            case enemyState.Aggro:

                break;

        }
        if (aggroMeter >= aggroMaximum)
        {
            state = enemyState.Aggro;
        }
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(gameObject.CompareTag("Player"))
        {
            aggroMeter *= Time.deltaTime;

        }
    }

}
