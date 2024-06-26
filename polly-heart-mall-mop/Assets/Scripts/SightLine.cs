using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightLine : MonoBehaviour
{
    public float aggroMeter;
    public float aggroMaximum;
    public EnemyAI enemy;




    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            aggroMeter *= Time.deltaTime;

            if (aggroMeter >= aggroMaximum)
            {
                enemy.state = EnemyAI.enemyState.Aggro;
            }

        }
    }
}
