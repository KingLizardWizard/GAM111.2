using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    Base baseObject;

    // Ints
    public int wood;
    public int metal;
    public int energyBoost;
    public int alarm;
    public int housePrice;
    public int houseEPrice;
    public int powerPlantPrice;
    public int powerPlantEPrice;
    public int metalFactoryWoodPrice;
    public int metalFactoryMetalPrice;
    public int metalFactoryEPrice;
    public int boosterWoodCost;
    public int boosterMetalCost;
    // FLoats
    public float maxEnergy;
    public float energy;
    // Bools
    public bool houseReady;
    public bool powerPlantReady;
    public bool metalFactoryReady;

    // Use this for initialization
    void Start () {
        baseObject = GameObject.FindGameObjectWithTag("Base").GetComponent<Base>();
        energy = maxEnergy;
    }
	
	// Update is called once per frame
	void Update () {
        // After every left click a test is made to see if there are enough resources
        // to build each structure, sets bools to true if they are or false if not
        if(Input.GetMouseButtonDown(0))
        {
            // House
            if (wood >= housePrice)
            {
                houseReady = true;
            }
            else
            {
                houseReady = false;
                baseObject.building = 0;
            }

            //PowerPlant
            if (metal >= powerPlantPrice)
            {
                powerPlantReady = true;
            }
            else
            {
                powerPlantReady = false;
                baseObject.building = 0;
            }

            // MetalFactory
            if (wood >= metalFactoryWoodPrice && metal >= metalFactoryMetalPrice)
            {
                metalFactoryReady = true;
            }
            else
            {
                metalFactoryReady = false;
                baseObject.building = 0;
            }
        }
        // Determines if the energy is within the specified zone
        // If it is then the resource buff is placed
        if (energy < 80 && energy > 50)
            energyBoost = 2; 
        else
            energyBoost = 1;
    }
}
