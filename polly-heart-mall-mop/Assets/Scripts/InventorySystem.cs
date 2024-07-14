using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : GameManager // inventory system script is attached to the gamemanager gameobject
{
    public ParticleSystem clothes; // particle system for the clothing, does not need to be defined in the inspector
    private bool hasClothes = false;
    public List<ClothingRack> clothingRacks = new List<ClothingRack>(); // list finds every clothing rack gameobject in the scene + adds them to the list, no need to declare in inspector
    public int clothesCollected = 0; // counter for the clothes collected

    public void OnEnable()
    {
        ClothingRack[] racks = FindObjectsOfType<ClothingRack>();
        foreach (ClothingRack rack in racks)
        {
            rack.LookedThroughClothingRack += OnLookedThrough;
            clothingRacks.Add(rack);
        }
    }

    private void OnDisable()
    {
        foreach (ClothingRack rack in clothingRacks)
        {
            if (rack != null)
            {
                rack.LookedThroughClothingRack -= OnLookedThrough;
            }
        }
    }

    public void OnLookedThrough(ParticleSystem clothes)
    {
        if (clothes != null)
        {
            clothes.Play();
            hasClothes = true;
            Debug.Log("Observer responds");
        }
        else
        {
            Debug.LogError("ParticleSystem not detected"); // error check
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void AddingClothes()
    {
        clothesCollected++;
        Debug.Log("Number of clothes collected: " + clothesCollected);
    }
}
