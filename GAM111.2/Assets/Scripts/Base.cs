using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Base : MonoBehaviour {

    public GameObject menu;

    public GameObject tile;

    public int building = 0;

    public bool buildReady = false;

    GameController gameController;

    public int upgradeCount;

    Queue<Vector3> buildingQueue = new Queue<Vector3>();

    // Use this for initialization
    void Start () {
        menu.SetActive(isShowing);

        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        Instantiate(tile, new Vector3(transform.position.x + 5f,transform.position.y - 1, transform.position.z), transform.rotation);
        Instantiate(tile, new Vector3(transform.position.x - 5f, transform.position.y - 1, transform.position.z), transform.rotation);
        Instantiate(tile, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z + 5f), transform.rotation);
        Instantiate(tile, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z - 5f), transform.rotation);

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
            building = 1;
    }

    public void PowerStationBuild()
    {
            building = 2;
    }

    public void MetalFactoryBuild()
    {
            building = 3;
    }

    public void Upgrade()
    {
        upgradeCount += 1;
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
        if (upgradeCount == 2)
        {
            Instantiate(tile, new Vector3(transform.position.x + 15f, transform.position.y - 1, transform.position.z), transform.rotation);
            Instantiate(tile, new Vector3(transform.position.x - 15f, transform.position.y - 1, transform.position.z), transform.rotation);
            Instantiate(tile, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z + 15), transform.rotation);
            Instantiate(tile, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z - 15), transform.rotation);
        }


    }

    private bool isShowing;
}
