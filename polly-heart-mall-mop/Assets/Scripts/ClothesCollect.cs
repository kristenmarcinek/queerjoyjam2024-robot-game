using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesCollect : ClothingRack
{
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

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
        int numEnter = particleSystem.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        InventorySystem manager = FindObjectOfType<InventorySystem>();
        for (int i = 0; i < numEnter; i++)
        {
            manager.AddingClothes();
        }

        particleSystem.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        Debug.Log("Number of particles in enter list: " + enter.Count);
    }
}
