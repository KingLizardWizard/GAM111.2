using UnityEngine;
using System.Collections;

public class Enemy1 : MonoBehaviour {

    private NavMeshAgent agent;
    public Vector3 destination;

    public float health = 100.0f;

    // Use this for initialization
    void Start()
    {
        destination = transform.position;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(destination);
    }

    public GameObject closestEnemy(Vector3 location, GameObject[] enemyList)
    {
        float enemyDistance = 0.0f;
        float nearestEnemyDistance = Mathf.Infinity;

        GameObject closest = null;
        //the foreach digs into the playerList and tests the follow method to all players in the scene, this is tested each game frame
        foreach (var go in enemyList)
        {
            //locates a new player
            enemyDistance = Vector3.Distance(go.transform.position, location);
            //tests to see if the new player is closer then the old one
            if (enemyDistance < nearestEnemyDistance)
            {
                //If it is then that player is tested and the closest enemy is decided
                nearestEnemyDistance = Vector3.Distance(go.transform.position, location);
                closest = go;
            }
        }
        //the player is sent to the back end of the program and is used as a target for the towers
        return closest;
    }

}
