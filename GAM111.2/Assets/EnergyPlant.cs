using UnityEngine;
using System.Collections;

public class EnergyPlant : MonoBehaviour {

    GameController gameController;

    public int energy;

    public float timer;
    // Use this for initialization
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && gameController.energy < 100)
        {
            gameController.energy += energy + 1;
            if (gameController.energy > 100)
                gameController.energy = gameController.maxEnergy;
            energy = 0;
            timer = 0.4f;
        }


    }

}
