using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
    Base baseObject;
    GameController gameController;
    UI uIController;

    public GameObject buildingDisplay;
    public GameObject house;
    public GameObject powerStation;
    public GameObject metalFactory;

    // Int's
    private int housePrice;
    private int powerPlantPrice;
    // Bool
    private bool buildReady = true;
    // Audio Component
    public AudioClip buildingPlaceSound;

    // Use this for initialization
    void Start () {
        baseObject = GameObject.FindGameObjectWithTag("Base").GetComponent<Base>();
        uIController = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnMouseOver()
    {
        // Tests if building is able to happen and which building to build
        if(Input.GetMouseButtonDown(0) && buildReady == true)
        {
            //Builds the house 
            if (baseObject.building == 1 && gameController.houseReady == true)
            {
                gameController.wood -= gameController.housePrice;
                Instantiate(house, transform.position, transform.rotation);
                AudioManager.instance.PlaySingle(buildingPlaceSound);
                buildReady = false;
                baseObject.houseMade = true;
            }
            else
                Debug.Log("Not Enough Resources!");

            // Builds the Power Plant
            if (baseObject.building == 2 && gameController.powerPlantReady == true)
            {
                gameController.metal -= gameController.powerPlantPrice;
                Instantiate(powerStation, transform.position, transform.rotation);
                AudioManager.instance.PlaySingle(buildingPlaceSound);
                buildReady = false;
            }
            else
                Debug.Log("Not Enough Resources!");

            // Builds the Metal Factory
            if (baseObject.building == 3 && gameController.metalFactoryReady == true)
            {
                gameController.wood -= gameController.metalFactoryWoodPrice;
                gameController.metal -= gameController.metalFactoryMetalPrice;
                Instantiate(metalFactory, transform.position, transform.rotation);
                AudioManager.instance.PlaySingle(buildingPlaceSound);
                buildReady = false;
            }
            else
                Debug.Log("Not Enough Resources!");
 
        }
    }
}
