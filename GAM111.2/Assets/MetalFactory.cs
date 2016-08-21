using UnityEngine;
using System.Collections;

public class MetalFactory : MonoBehaviour {

    GameController gameController;

    public int metal;

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
        if (timer <= 0)
        {
            gameController.energy -= 0.5f;
            gameController.metal += metal + 1;
            metal = 0;
            timer = 0.4f;
        }
    }
}

