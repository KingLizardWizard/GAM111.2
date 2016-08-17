using UnityEngine;
using System.Collections;

public class Warrior : MonoBehaviour {

    private NavMeshAgent agent;
    public Vector3 destination;

    public float maxHealth = 100.0f;
    public float health = 100.0f;

    public bool hidden = false;

    // Use this for initialization
    void Start()
    {
        destination = transform.position;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveTo(Vector3 newDestination)
    {
        destination = newDestination;
    }

    public void UpgradeHealth()
    {
        maxHealth += 20.0f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cover")
            hidden = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Cover")
            hidden = false;
    }
}
