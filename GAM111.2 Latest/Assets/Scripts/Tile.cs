using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
    Base baseObject;
    public GameObject buildingDisplay;
    public GameObject house;
    public GameObject tile;

    GameController gameController;
    Tile tileSpawn;

	// Use this for initialization
	void Start () {
        baseObject = GameObject.FindGameObjectWithTag("Base").GetComponent<Base>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        tileSpawn = GameObject.FindGameObjectWithTag("tileSpawn").GetComponent<Tile>();
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

    public void UpgradeClick()
    {
        tileSpawn.Upgrade();
    }

    public void Upgrade()
    {
        Instantiate(tile, new Vector3(transform.position.x - 5f, transform.position.y - 1f, transform.position.z), transform.rotation);
        Instantiate(tile, new Vector3(transform.position.x + 5f, transform.position.y - 1f, transform.position.z), transform.rotation);
        Instantiate(tile, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), transform.rotation);
        Instantiate(tile, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z - 5f), transform.rotation);
    }

    void OnMouseEnter()
    {
        //Used for adding an object overaly when you select the tile to use
        //Instantiate(buildingDisplay, transform.position, transform.rotation);
    }
}
