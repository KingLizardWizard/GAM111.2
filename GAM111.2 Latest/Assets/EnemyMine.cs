using UnityEngine;
using System.Collections;

public class EnemyMine : MonoBehaviour {

    private Transform target = null;

	// Use this for initialization
	void Start () {
       

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            target = other.transform;
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") target = null;
    }
}
