using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : InventorySystem // playerinventory inherits from the gamemanager's inventory system to give the player their own inventory to be used in the dress up portion
// based on clothesCollected int, it will disperse the number across the different categories
// in total, there will be 26 items that can be collected
// 6 shirts, 4 pants, 3 full-body outfits (shirt + pants), 4 faces of makeup, 4 pairs of shoes, 1 pair of gloves, 3 hats, 1 pair of glasses
// this makes 8 categories of clothes
// each category has a max number of clothes that can be collected
// these clothes will then be spawned into the character creator scene based on the dispersed number
// ie if clothesCollected is 6, it will proportionately disperse this number across the 8 categories to instantiate the correct number of clothes in the charactercreator scene
{
    [field: Header("Set Items")] // maximum number of items in each category
    private readonly int maxShirts = 6;
    private readonly int maxPants = 4;
    private readonly int maxFullBody = 3;
    private readonly int maxMakeup = 4;
    private readonly int maxShoes = 4;
    private readonly int maxGloves = 1;
    private readonly int maxHats = 3;
    private readonly int maxGlasses = 1;

    [field: Header("Items Collected")] // number of items collected in each category
    public int shirtsCollected = 0;
    public int pantsCollected = 0;
    public int fullBodyCollected = 0;
    public int makeupCollected = 0;
    public int shoesCollected = 0;
    public int glovesCollected = 0;
    public int hatsCollected = 0;
    public int glassesCollected = 0;

    [field: Header("Declarations")]
    public List<ClothesCollect> clothingItems = new List<ClothesCollect>();

    public void OnEnable()
    {
        ClothesCollect[] clothingItems = FindObjectsOfType<ClothesCollect>(); // getting all the particles
        foreach (ClothesCollect item in clothingItems)
        {
            item.ClothesCollection += DisperseClothes; // Subscribe to the ClothesCollection event
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

    public void DisperseClothes()
    {
        InventorySystem manager = FindObjectOfType<InventorySystem>(); // finds the inventory system in the scene

        // reset counts to update proportions every time something is collected
        shirtsCollected = 0;
        pantsCollected = 0;
        fullBodyCollected = 0;
        makeupCollected = 0;
        shoesCollected = 0;
        glovesCollected = 0;
        hatsCollected = 0;
        glassesCollected = 0;

        // calculate proportions per category
        float totalCategories = 8f; // categories of clothes
        float proportion = manager.clothesCollected / totalCategories;

        // distribute clothes to each variable
        shirtsCollected = Mathf.Min(maxShirts, Mathf.FloorToInt(proportion));
        pantsCollected = Mathf.Min(maxPants, Mathf.FloorToInt(proportion));
        fullBodyCollected = Mathf.Min(maxFullBody, Mathf.FloorToInt(proportion));
        makeupCollected = Mathf.Min(maxMakeup, Mathf.FloorToInt(proportion));
        shoesCollected = Mathf.Min(maxShoes, Mathf.FloorToInt(proportion));
        glovesCollected = Mathf.Min(maxGloves, Mathf.FloorToInt(proportion));
        hatsCollected = Mathf.Min(maxHats, Mathf.FloorToInt(proportion));
        glassesCollected = Mathf.Min(maxGlasses, Mathf.FloorToInt(proportion));

        Debug.Log("Clothes distribution: ");
        Debug.Log("Shirts: " + shirtsCollected);
        Debug.Log("Pants: " + pantsCollected);
        Debug.Log("FullBody: " + fullBodyCollected);
        Debug.Log("Makeup: " + makeupCollected);
        Debug.Log("Shoes: " + shoesCollected);
        Debug.Log("Gloves: " + glovesCollected);
        Debug.Log("Hats: " + hatsCollected);
        Debug.Log("Glasses: " + glassesCollected);
    }
}
