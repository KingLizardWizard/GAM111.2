using UnityEngine;
using System.Collections;

public class UfoBeamTrigger : MonoBehaviour {

    public bool fire = false;

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
        {
            fire = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            fire = false;
        }
    }
}
