using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
    Base baseObject;
    public GameObject buildingDisplay;
    public GameObject house;

    GameController gameController;

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
        if(Input.GetMouseButtonDown(0))
        {
            if (baseObject.building == 1 && gameController.wood >= 100)
            {
                gameController.wood -= 100;
                Instantiate(house, transform.position, transform.rotation);
            }
        }
    }

    void OnMouseEnter()
    {
        //Used for adding an object overaly when you select the tile to use
        //Instantiate(buildingDisplay, transform.position, transform.rotation);
    }
}
