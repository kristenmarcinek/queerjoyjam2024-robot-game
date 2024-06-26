using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothingRack : MonoBehaviour
{
    public ParticleSystem clothes;
    public bool inCollider;
    private bool hasClothes = true;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hasClothes)
        {
            if (Input.GetKeyDown(KeyCode.E) && inCollider == true) //checks if player is colliding with clothing rack
            {
                Debug.Log("Collide1");
                clothes.Play();
                hasClothes = false;
            }
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("collide");
        if(collision.gameObject.CompareTag("Player"))
        {
            inCollider = true;

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inCollider = false;
    }
    /*private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("collide with player");
            Destroy(this.gameObject); //destroys clothing particle when collided with
        }


    }
    */


}
