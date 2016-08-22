using UnityEngine;
using System.Collections;

public class UFO : MonoBehaviour {

    // Targets to move to
    public Transform target;
    public Transform target2;
    public Transform target3;
    public Transform target4;
    public Transform target5;
    public Transform target6;
    public Transform target7;
    // Floats
    public float speed;
    public float timer;
    // Int
    public int targetNo;
    // Bool
    public bool noAttack;

    // The different states the UFO can go to
    public enum UfoState
    {
        Roaming,
        Attack
    }

    public UfoState ufoState;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        // Tests is the UFO is romaing, if it is it begins it's infinite movement between targets
        float step = speed * Time.deltaTime;
        if (ufoState == UfoState.Roaming)
        {
            // Tests which target it's at
            if (targetNo == 1)
            {
                // Moves towards the target
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);
                // Once the target is within a certain distance change the target to the next
                if (Vector3.Distance(transform.position, target.position) < 0.1f)
                {
                    targetNo++;
                }
            }
            if (targetNo == 2)
            {
                transform.position = Vector3.MoveTowards(transform.position, target2.position, step);
                if (Vector3.Distance(transform.position, target2.position) < 0.1f)
                {
                    targetNo++;
                }
            }
            if (targetNo == 3)
            {
                transform.position = Vector3.MoveTowards(transform.position, target3.position, step);
                if (Vector3.Distance(transform.position, target3.position) < 0.1f)
                {
                    targetNo++;
                }
            }
            if (targetNo == 4)
            {
                transform.position = Vector3.MoveTowards(transform.position, target4.position, step);
                if (Vector3.Distance(transform.position, target4.position) < 0.1f)
                {
                    targetNo++;
                }
            }
            if (targetNo == 5)
            {
                transform.position = Vector3.MoveTowards(transform.position, target5.position, step);
                if (Vector3.Distance(transform.position, target5.position) < 0.1f)
                {
                    targetNo++;
                }
            }
            if (targetNo == 6)
            {
                transform.position = Vector3.MoveTowards(transform.position, target6.position, step);
                if (Vector3.Distance(transform.position, target6.position) < 0.1f)
                {
                    targetNo++;
                }
            }
            if (targetNo == 7)
            {
                transform.position = Vector3.MoveTowards(transform.position, target7.position, step);
                // If the last target is within the distance then set the target back to the start (1)
                if (Vector3.Distance(transform.position, target7.position) < 0.1f)
                {
                    targetNo = 1;
                }
            }
        }
        else
        {
            // If the UFO is in an attack state stop to show an attack
            if (ufoState == UfoState.Attack)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    ufoState = UfoState.Roaming;
                }
            }
        }
    }

    // If the trigger which enters is a player then sent state to attack
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            ufoState = UfoState.Attack;
    }

}


    

