using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    Base baseObject;

    public int wood;
    public float maxEnergy;
    public float energy;
    public int metal;

    public int alarm;

    public int housePrice;
    public int houseEPrice;
    public int powerPlantPrice;
    public int powerPlantEPrice;
    public int metalFactoryWoodPrice;
    public int metalFactoryMetalPrice;
    public int metalFactoryEPrice;

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
        if(Input.GetMouseButtonDown(0))
        {
            if (wood >= housePrice)
            {
                houseReady = true;
            }
            else
            {
                houseReady = false;
                baseObject.building = 0;
            }

            if (metal >= powerPlantPrice)
            {
                powerPlantReady = true;
            }
            else
            {
                powerPlantReady = false;
                baseObject.building = 0;
            }

            if (wood >= metalFactoryWoodPrice && metal >= metalFactoryMetalPrice)
            {
                metalFactoryReady = true;
            }
            else
            {
                metalFactoryReady = false;
                baseObject.building = 0;
            }

            if (energy <= 50)
                alarm = 2;
        }

        if(Input.GetKeyDown("j"))
        {
            wood += 300;
            metal += 300;
        }
    }
}
