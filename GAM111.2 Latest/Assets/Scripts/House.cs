using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class House : MonoBehaviour {

    public GameObject villager;
    public GameObject miner;

    public Queue<string> unitQueue;

    public string currentUnit = "none";
    public string villagerUnit = "villager";
    public string minerUnit = "miner";

    public float maxUnitProgress;
    public float unitProgress;

    public bool spawnUnits = false;

    // Use this for initialization
    void Start () {
        unitQueue = new Queue<string>();
        
    }

	// Update is called once per frame
	void Update () {
        SpawnVillager();

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
