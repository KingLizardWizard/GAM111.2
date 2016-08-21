using UnityEngine;
using System.Collections;

public class UFO : MonoBehaviour {

    public Transform target;
    public Transform target2;
    public Transform target3;
    public Transform target4;
    public Transform target5;
    public Transform target6;
    public Transform target7;

    public float speed;
    public int targetNo;

    public float timer;

    public bool noAttack;

    //Player State Enumerator Construct
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
        float step = speed * Time.deltaTime;
        if (ufoState == UfoState.Roaming)
        {
            if (targetNo == 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);
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
                if (Vector3.Distance(transform.position, target7.position) < 0.1f)
                {
                    targetNo = 1;
                }
            }
        }
        else
        {
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

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            ufoState = UfoState.Attack;
    }

}


    

