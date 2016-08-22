using UnityEngine;
using System.Collections;

public class WoodTrigger : MonoBehaviour {

    GameController gameController;

    // Int's
    public int currentWood;
    public int noVillagers;
    public int maxHealth;
    public int boost;
    private int gatheringMultiplier = 11;
    // Float
    public float Timer;


    // Use this for initialization
    void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
        // A timer which increases wood depending on how many villagers are in it
        // Also tests if a booster is in the resuorce spot and if the resource buff is on
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            currentWood += noVillagers * gatheringMultiplier * boost * gameController.energyBoost;
            if (currentWood > maxHealth)
            {
                gameController.wood += maxHealth;
            }
            else
            {
                gameController.wood += currentWood;
            }
            maxHealth -= currentWood;
            currentWood = 0;
            
            Timer = 2.0f;

            // Once all of the resources are depleted, destroys self
            if (maxHealth <= 0)
                Destroy(this.gameObject);        
        }
	}

    // Tests if the trigger entered is a villager or a booster
    // increases variables if so
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            noVillagers += 1;
   
        if (other.tag == "Building")
            boost += 1;
    }

    // Tests if the trigger exiting is a villager or a booster
    // reduces variables if so
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            noVillagers -= 1;
        
        if (other.tag == "Building")
            boost -= 1;
    }
}
