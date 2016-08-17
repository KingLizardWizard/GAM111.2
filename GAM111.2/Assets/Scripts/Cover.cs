using UnityEngine;
using System.Collections;

public class Cover : MonoBehaviour {

    public int noVillagers;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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
