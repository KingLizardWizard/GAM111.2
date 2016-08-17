using UnityEngine;
using System.Collections;

public class WoodTrigger : MonoBehaviour {

    GameController gameController;

    public int currentWood;
    public int noVillagers;
    public int maxHealth;

    public float Timer;


    // Use this for initialization
    void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            currentWood += noVillagers * 4;
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

            if (maxHealth <= 0)
                Destroy(this.gameObject);        
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            noVillagers += 1;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            noVillagers -= 1;
    }
}
