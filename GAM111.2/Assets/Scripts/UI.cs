using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI : MonoBehaviour {
    public GameObject houseMenu;
    public GameObject houseCosts;

    GameController gameController;
    Base baseObject;
    Rocket rocket;

    // Bool
    public bool isShowing;
    // Texts
    public Text woodText;
    public Text metalText;
    public Text houseWoodText;
    public Text powerMetalText;
    public Text factoryWoodText;
    public Text factoryMetalText;
    public Text upgradeWoodText;
    public Text upgradeMetalText;
    public Text boosterWoodText;
    public Text boosterMetalText;
    public Text villagerPriceText;
    public Text thrustersWoodText;
    public Text thrustersMetalText;
    public Text baseWoodText;
    public Text baseMetalText;
    public Text topWoodText;
    public Text topMetalText;
    public Text villagerText;
    public Slider healthText;
    // Float
    public float energyUI;
    // Int's
    public int woodUI;
    public int metalUI;
    public int villagerUI;
    public int upgradeLevel = 10;

    // Use this for initialization 
    void Start()
    {
        houseMenu.SetActive(isShowing);
        houseCosts.SetActive(isShowing);
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        baseObject = GameObject.FindGameObjectWithTag("Base").GetComponent<Base>();
        rocket = GameObject.FindGameObjectWithTag("Rocket").GetComponent<Rocket>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Sets all the text in the game
    void SetText()
    {
        // Villager count
        baseObject = GameObject.FindGameObjectWithTag("Base").GetComponent<Base>();
        villagerUI = baseObject.villagerCount;   
        // Wood count
        woodText.text = "Wood: " + woodUI.ToString();
        woodUI = gameController.wood;
        // Metal Count
        metalText.text = "Metal: " + metalUI.ToString();
        metalUI = gameController.metal;
        // Energy Bar count
        healthText.value = gameController.energy;
        // Changes the max value for villagers depending if the villagerCount is past 10
        if (villagerUI < upgradeLevel)
            villagerText.text = "Villagers: " + villagerUI.ToString() + "/" + upgradeLevel;
        else
            villagerText.text = "Villager: MAX";

        // BaseBuildings for main panel
        houseWoodText.text = gameController.housePrice.ToString();
        powerMetalText.text = gameController.powerPlantPrice.ToString();
        factoryWoodText.text = gameController.metalFactoryWoodPrice.ToString();
        factoryMetalText.text = gameController.metalFactoryMetalPrice.ToString();
        boosterWoodText.text = gameController.boosterWoodCost.ToString();
        boosterMetalText.text = gameController.boosterMetalCost.ToString();
        powerMetalText.text = gameController.powerPlantPrice.ToString();
        houseWoodText.text = gameController.housePrice.ToString();
        powerMetalText.text = gameController.powerPlantPrice.ToString();
        upgradeWoodText.text = baseObject.upgradeWoodCost.ToString();
        upgradeMetalText.text = baseObject.upgradeMetalCost.ToString();

         // ExtraBuildings for extra buildings panel
         thrustersWoodText.text = rocket.ThrustersWoodPrice.ToString();
         thrustersMetalText.text = rocket.ThrustersMetalPrice.ToString();
         baseWoodText.text = rocket.BaseWoodPrice.ToString();
         baseMetalText.text = rocket.BaseMetalPrice.ToString();
         topWoodText.text = rocket.TopWoodPrice.ToString();
         topMetalText.text = rocket.TopMetalPrice.ToString();
         villagerPriceText.text = baseObject.villagerPrice.ToString();
    }
}
