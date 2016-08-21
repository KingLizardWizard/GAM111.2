using UnityEngine;
using System.Collections;

public class MetalTrigger : MonoBehaviour {

    GameController gameController;

    public int currentMetal;
    public int noVillagers;
    public int maxHealth;
    public int boost;

    public float Timer;

    // Use this for initialization
    void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            currentMetal += noVillagers * 4 * boost;
            if (currentMetal > maxHealth)
            {
                gameController.metal += maxHealth;
            }
            else
            {
                gameController.metal += currentMetal;
            }
            maxHealth -= currentMetal;
            currentMetal = 0;

            Timer = 2.0f;

            if (maxHealth <= 0)
                Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            noVillagers += 1;

        if (other.tag == "Building")
            boost += 1;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            noVillagers -= 1;

        if (other.tag == "Building")
            boost -= 1;
    }
}
