using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class House : MonoBehaviour {

    public GameObject villager;
    public GameObject miner;

    GameController gameController;
    UI UIController;

    public Queue<string> unitQueue;

    public string currentUnit = "none";
    public string villagerUnit = "villager";
    public string minerUnit = "miner";

    public float maxUnitProgress;
    public float unitProgress;
    public float timer;

    public bool spawnUnits = false;

    // Use this for initialization
    void Start () {
     //   menu.SetActive(isShowing);

        unitQueue = new Queue<string>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        UIController = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UIController.isShowing = !UIController.isShowing;
            UIController.houseMenu.SetActive(UIController.isShowing);
        }
    }

    // Update is called once per frame
    void Update () {
        SpawnVillager();
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            gameController.energy -= 0.5f;
            timer = 0.4f;
        }
    }

    public void AddVillager()
    {
        unitQueue.Enqueue(villagerUnit);
        spawnUnits = true;
    }

    public void AddMiner()
    {
        unitQueue.Enqueue(minerUnit);
        spawnUnits = true;
    }

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
                if (currentUnit == minerUnit)
                {
                    Instantiate(miner, transform.position + (transform.forward * 2), transform.rotation);
                    resetQueue();
                }
            }
            
        }
       
    }

}
