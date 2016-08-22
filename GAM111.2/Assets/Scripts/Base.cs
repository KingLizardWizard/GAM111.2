using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Base : MonoBehaviour {

    // Panel Options
    public GameObject menu;
    public GameObject basePrices;
    public GameObject houseMenu;
    public GameObject housePrices;

    // Prefabs to use
    public GameObject tile;
    public GameObject villager;
    public GameObject bomber;

    // an Array to count how many villagers there are
    private GameObject[] getVillagerCount;
    public int villagerCount;

    public AudioClip menuSelect;

    GameController gameController;
    UI uIController;

    // Ints
    public int building = 0;
    public int upgradeCount;
    public int upgradeWoodCost;
    public int upgradeMetalCost;
    public int villagerPrice;
    public int bomberPrice;
    // Bools
    public bool buildReady = false;
    public bool spawnUnits = false;
    public bool houseMade = false;
    private bool isShowing;
    // Queue
    Queue<Vector3> buildingQueue = new Queue<Vector3>();
    public Queue<string> unitQueue;
    // Strings
    public string currentUnit = "none";
    public string villagerUnit = "villager";
    public string bomberUnit = "bomber";
    // Floats
    public float maxUnitProgress;
    public float unitProgress;
    public float timer;

    // Use this for initialization
    void Start () {
        // Setting the panels
        menu.SetActive(isShowing);
        basePrices.SetActive(isShowing);
        houseMenu.SetActive(isShowing);
        housePrices.SetActive(isShowing);

        unitQueue = new Queue<string>();

        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        uIController = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();

        // Instantiating the 1st tiles
        Instantiate(tile, new Vector3(transform.position.x + 5f,transform.position.y - 1, transform.position.z), transform.rotation);
        Instantiate(tile, new Vector3(transform.position.x - 5f, transform.position.y - 1, transform.position.z), transform.rotation);
        Instantiate(tile, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z + 5f), transform.rotation);
        Instantiate(tile, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z - 5f), transform.rotation);

    }
	
	// Update is called once per frame
	void Update () {
        SpawnVillager();
        // When a house has been creating, set the house panels to true
        if(houseMade == true)
        {
            housePrices.SetActive(isShowing);
            houseMenu.SetActive(isShowing);
        }

    }

    // When the base has been clicked on, tick on/off panels
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AudioManager.instance.PlaySingle(menuSelect);
            isShowing = !isShowing;
            menu.SetActive(isShowing);
            basePrices.SetActive(isShowing);
        }
    }

    // These 3 functions activate when the corresponding button has been pressed
    // Sends a message to each tile prefab to let them know which building is pressed
    public void HouseBuild()
    {
        AudioManager.instance.PlaySingle(menuSelect);
        building = 1;
    }

    public void PowerStationBuild()
    {
        AudioManager.instance.PlaySingle(menuSelect);
        building = 2;
    }

    public void MetalFactoryBuild()
    {
        AudioManager.instance.PlaySingle(menuSelect);
        building = 3;
    }

    // Upgrades the building by adding more tiles to use
    public void Upgrade()
    {
        // If the player has enough resources, continue with the function
        if (gameController.wood > upgradeWoodCost && gameController.metal > upgradeMetalCost)
        {
            gameController.wood -= upgradeWoodCost;
            gameController.metal -= upgradeMetalCost;
            upgradeMetalCost *= 2;
            upgradeWoodCost *= 2;
            AudioManager.instance.PlaySingle(menuSelect);
            // The upgradeLevel variable will always increase with upgrades, this increase the max amount of villagers
            uIController.upgradeLevel += 5;
            upgradeCount += 1;
            // Upgrade for tier 2
            if (upgradeCount == 1)
            {
                Instantiate(tile, new Vector3(transform.position.x + 10f, transform.position.y - 1, transform.position.z), transform.rotation);
                Instantiate(tile, new Vector3(transform.position.x + 5, transform.position.y - 1, transform.position.z + 5), transform.rotation);
                Instantiate(tile, new Vector3(transform.position.x + 5, transform.position.y - 1, transform.position.z - 5), transform.rotation);
                Instantiate(tile, new Vector3(transform.position.x - 10f, transform.position.y - 1, transform.position.z), transform.rotation);
                Instantiate(tile, new Vector3(transform.position.x - 5, transform.position.y - 1, transform.position.z + 5), transform.rotation);
                Instantiate(tile, new Vector3(transform.position.x - 5, transform.position.y - 1, transform.position.z - 5), transform.rotation);
                Instantiate(tile, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z + 10), transform.rotation);
                Instantiate(tile, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z - 10), transform.rotation);
            }
            //Upgrade for tier 3
            if (upgradeCount == 2)
            {
                Instantiate(tile, new Vector3(transform.position.x + 15f, transform.position.y - 1, transform.position.z), transform.rotation);
                Instantiate(tile, new Vector3(transform.position.x - 15f, transform.position.y - 1, transform.position.z), transform.rotation);
                Instantiate(tile, new Vector3(transform.position.x - 10f, transform.position.y - 1, transform.position.z -5), transform.rotation);
                Instantiate(tile, new Vector3(transform.position.x - 10f, transform.position.y - 1, transform.position.z + 5), transform.rotation);
                Instantiate(tile, new Vector3(transform.position.x + 10f, transform.position.y - 1, transform.position.z - 5), transform.rotation);
                Instantiate(tile, new Vector3(transform.position.x + 10f, transform.position.y - 1, transform.position.z + 5), transform.rotation);
                Instantiate(tile, new Vector3(transform.position.x - 5, transform.position.y - 1, transform.position.z - 10), transform.rotation);
                Instantiate(tile, new Vector3(transform.position.x + 5, transform.position.y - 1, transform.position.z - 10), transform.rotation);
                Instantiate(tile, new Vector3(transform.position.x - 5, transform.position.y - 1, transform.position.z + 10), transform.rotation);
                Instantiate(tile, new Vector3(transform.position.x + 5, transform.position.y - 1, transform.position.z + 10), transform.rotation);
                Instantiate(tile, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z + 15), transform.rotation);
                Instantiate(tile, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z - 15), transform.rotation);
            }
        }
    }

    //Adds a villager to the queue
    public void AddVillager()
    {
        // Tests if the villager count is at max / if there are enough resources
        if (villagerCount + unitQueue.Count < uIController.upgradeLevel && gameController.metal > villagerPrice)
        {
            gameController.metal -= villagerPrice;
            unitQueue.Enqueue(villagerUnit);
            spawnUnits = true;
        }
    }

    //Adds a bomber to the queue
    public void AddBomber()
    {
        // Tests if the villager count is at max / if there are enough resources
        if (villagerCount + unitQueue.Count < uIController.upgradeLevel)
        {
            gameController.metal -= bomberPrice;
            unitQueue.Enqueue(bomberUnit);
            spawnUnits = true;
        }
    }

    // This is called everytime a villager is instantiated, Tests if the queue is empty
    // If it's empty the timers turn off
    private void resetQueue()
    {
        if (unitQueue.Count == 0)
        {
            spawnUnits = false;
            unitProgress = maxUnitProgress;
        }
        else
        {
            unitProgress = maxUnitProgress;
        }
    }

    // Activates when there are units in the queue and instantiates different units depending
    // which is 1st in the queue
    public void SpawnVillager()
    {
        if (spawnUnits == true)
        {
            unitProgress -= Time.deltaTime;
            if (unitProgress <= 0)
            {
                currentUnit = unitQueue.Dequeue();
                if (currentUnit == villagerUnit)
                {
                    Instantiate(villager, transform.position + (transform.forward * 2), transform.rotation);
                    resetQueue();
                }
                if (currentUnit == bomberUnit)
                {
                    Instantiate(bomber, transform.position + (transform.forward * 2), transform.rotation);
                    resetQueue();
                }
                // Is used in the UI script to show how many villagers there are currently
                getVillagerCount = GameObject.FindGameObjectsWithTag("Player");
                villagerCount = getVillagerCount.Length;
            }
        }
    }
}
