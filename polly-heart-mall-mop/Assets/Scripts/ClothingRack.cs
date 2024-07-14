using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClothingRack : MonoBehaviour
{
    public event UnityAction<ParticleSystem> LookedThroughClothingRack; // trying out the observer pattern here
    private ParticleSystem clothes; // particle system for the clothing, does not need to be defined in the inspector
    public bool inCollider;
    private bool hasClothes = false; // i just cswitched this to false and true down below because it made more sense to me but it did not really matter lol
    
    void Start()
    {
        clothes = GetComponentInChildren<ParticleSystem>(); // gets the particle system component from the children of the clothing rack
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasClothes) // if hasClothes is false
        {
            if (Input.GetKeyDown(KeyCode.E) && inCollider == true) //checks if player is colliding with clothing rack
            {
                Debug.Log("Collide1");
                hasClothes = true;
                LookedThroughClothingRack?.Invoke(clothes); // invokes the observer pattern within inventorysystem script
            }
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision) // clothing rack collision
    {
        Debug.Log("collide");
        if(collision.gameObject.CompareTag("Player"))
        {
            inCollider = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision) // clothing rack collision
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
