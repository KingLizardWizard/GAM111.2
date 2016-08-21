using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
    Base baseObject;
    GameController gameController;

    public GameObject buildingDisplay;
    public GameObject house;
    public GameObject powerStation;
    public GameObject metalFactory;

    private int housePrice;
    private int powerPlantPrice;

    private bool buildReady = true;

	// Use this for initialization
	void Start () {
        baseObject = GameObject.FindGameObjectWithTag("Base").GetComponent<Base>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0) && buildReady == true)
        {
            if (baseObject.building == 1 && gameController.houseReady == true)
            {
                gameController.wood -= gameController.housePrice;
                Instantiate(house, transform.position, transform.rotation);
                buildReady = false;
            }
            else
                Debug.Log("Not Enough Resources!");

            if (baseObject.building == 2 && gameController.powerPlantReady == true)
            {
                gameController.metal -= gameController.powerPlantPrice;
                Instantiate(powerStation, transform.position, transform.rotation);
                buildReady = false;
            }
            else
                Debug.Log("Not Enough Resources!");

            if (baseObject.building == 3 && gameController.metalFactoryReady == true)
            {
                gameController.wood -= gameController.metalFactoryWoodPrice;
                gameController.metal -= gameController.metalFactoryMetalPrice;
                Instantiate(metalFactory, transform.position, transform.rotation);
                buildReady = false;
            }
            else
                Debug.Log("Not Enough Resources!");
 
        }
    }

    void OnMouseEnter()
    {
        //Used for adding an object overaly when you select the tile to use
        //Instantiate(buildingDisplay, transform.position, transform.rotation);
    }
}
