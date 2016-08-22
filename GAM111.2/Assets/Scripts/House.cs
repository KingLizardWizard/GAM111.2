using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class House : MonoBehaviour {

    Base baseObject;
    GameController gameController;

    // Float
    public float timer;

    // Use this for initialization
    void Start () { 
        baseObject = GameObject.FindGameObjectWithTag("Base").GetComponent<Base>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        // Sets a baseObject script variable to true, which shows a house has been made
        // this is used to open the house panel when this object is made
        baseObject.houseMade = true;
    }

    void Update()
    {
        // A timer for gaining energy overtime
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            gameController.energy -= 0.1f;
            timer = 0.1f;
        }
    }

}
