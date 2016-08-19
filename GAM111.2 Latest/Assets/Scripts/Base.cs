using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Base : MonoBehaviour {

    public GameObject menu;

    public GameObject tile;

    public int building = 0;

    public bool buildReady = false;

    GameController gameController;

    Queue<Vector3> buildingQueue = new Queue<Vector3>();

	// Use this for initialization
	void Start () {
        menu.SetActive(isShowing);

        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        Instantiate(tile, new Vector3(transform.position.x - 5f, transform.position.y - 1f, transform.position.z), transform.rotation);
        Instantiate(tile, new Vector3(transform.position.x + 5f, transform.position.y - 1f, transform.position.z), transform.rotation);
        Instantiate(tile, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 5f), transform.rotation);
        Instantiate(tile, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z - 5f), transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isShowing = !isShowing;
            menu.SetActive(isShowing);
            if (buildReady == false)
            buildReady = true;
        }
    }

    public void HouseBuild()
    {
        if (gameController.wood >= 100)
        {
            building = 1;
        }
        else
            Debug.Log("Not Enough Coin!");
    }

    /*public void Build()
    {
        if (buildReady == true)
        {
            if (building == 1)
            Instantiate(tile, new Vector3(3.5f, 0, -1.1f), transform.rotation);
        }
    }*/

    private bool isShowing;
}
