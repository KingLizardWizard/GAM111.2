using UnityEngine;
using System.Collections;

public class EnemyBuilding : MonoBehaviour {

    public int currentHealth;
    public int noPlayers;
    public int maxHealth;

    public float Timer;

    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(noPlayers > 0)
        Timer -= Time.deltaTime;
        if (Timer <= 0 && noPlayers > 0)
        {
            currentHealth -= noPlayers * 4;       
            Timer = 1.0f;
            if (currentHealth <= 0)
                Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            noPlayers += 1;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            noPlayers -= 1;
    }
}
