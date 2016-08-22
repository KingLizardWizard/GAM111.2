using UnityEngine;
using System.Collections;

public class MetalFactory : MonoBehaviour {

    GameController gameController;
    Rocket rocket;

    // Int
    public int metal;
    // bool
    public bool factory;
    // float
    public float timer;
    // Use this for initialization
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        rocket = GameObject.FindGameObjectWithTag("Rocket").GetComponent<Rocket>();
        // Shows that a factory has been made
        // when set to true, one of the requirments to build a rocket is set
        rocket.factory = true;
    }

    // Update is called once per frame
    void Update()
    {
        // A timer to reduce energy overtime and gain metal overtime
        // Tests if the resource buff is on
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            gameController.energy -= 0.25f;
            gameController.metal += (metal + 1) * gameController.energyBoost;
            metal = 0;
            timer = 0.2f;
        }
    }
}

