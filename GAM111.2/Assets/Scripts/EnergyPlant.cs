using UnityEngine;
using System.Collections;

public class EnergyPlant : MonoBehaviour {

    GameController gameController;
    Rocket rocket;
    // Floats
    public float energy;
    public float timer;
    // Bools
    public bool powerPlant;

    // Use this for initialization
    void Start()
    {        
        powerPlant = true;
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        rocket = GameObject.FindGameObjectWithTag("Rocket").GetComponent<Rocket>();
        rocket.powerPlant = true;
    }

    // Update is called once per frame
    void Update()
    {
        // A timer event to gain energy overtime
        timer -= Time.deltaTime;
        if (timer <= 0 && gameController.energy < 100)
        {
            gameController.energy += energy + 0.3f;
            if (gameController.energy > 100)
                gameController.energy = gameController.maxEnergy;
            energy = 0;
            timer = 0.1f;
        }


    }

}
