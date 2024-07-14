using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClothesCollect : ClothingRack
{
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>(); // get all the particles from the particle system attached to each clothing rack
    public UnityAction ClothesCollection; // event for the clothes collected
    public PlayerInventory playerInventory; // reference to the playerinventory script

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnParticleTrigger() // i moved this from the playercontroller script to here, i'm assuming it is supposed to collect upon collision with the particle system?
    // on the particle system object ("clothes" in inventorysystem.cs & "clothes flinger" in scene), i checked off triggers + set enter to callback and exit to kill
    {
        Debug.Log("Particles are colliding");
        ParticleSystem particleSystem = GetComponent<ParticleSystem>();
        int numEnter = particleSystem.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter); // list of particles that have entered the trigger
        InventorySystem manager = FindObjectOfType<InventorySystem>(); // finds the inventory system in the scene
        for (int i = 0; i < numEnter; i++)
        {
            manager.AddingClothes(); // overrides the clothesCollected int in the inventory system
        }

        ClothesCollection?.Invoke();
        particleSystem.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter); // sets the particles that have entered the trigger
    }
}
