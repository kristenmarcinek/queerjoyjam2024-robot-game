using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;

    public enum enemyState
    {
        Patrol,
        Suspicious,
        Aggro
    }
    

    public enemyState state;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        switch (state)
        {
            case enemyState.Patrol:

                break;
            case enemyState.Suspicious:

                break;
            case enemyState.Aggro:

                break;


        }
     
    }

    private void SpotPlayer()
    {

    }

    /* ignore I realized this was all unecessary
    
        }*/

}
