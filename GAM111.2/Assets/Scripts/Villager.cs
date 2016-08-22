using UnityEngine;
using System.Collections;

public class Villager : MonoBehaviour {
    Base baseObject;

    private NavMeshAgent agent;
    // V3
    public Vector3 destination;
    // Floats
    public float maxHealth = 100.0f;
    public float health = 100.0f;
    // Bool
    public bool hidden = false;
    // Audio Component
    public AudioClip deathSound;

    // Use this for initialization
    void Start()
    {
        baseObject = GameObject.FindGameObjectWithTag("Base").GetComponent<Base>();
        
        // Sets the villager destination to itself so it doens't move
        destination = transform.position;
        agent = GetComponent<NavMeshAgent>();
  
        //   agent.acceleration = 5;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(destination);
    }

    // Sets a new distination when this function is called
    public void MoveTo(Vector3 newDestination)
    {
        destination = newDestination;
    }

    // When collides with a trigger if it's a UFO minus villagerCount and destroy self
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "UFO")
        {
            baseObject.villagerCount -= 1;
            AudioManager.instance.PlaySingle(deathSound);
            Destroy(this.gameObject);
        }
    }
}
