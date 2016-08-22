using UnityEngine;
using System.Collections;

public class BuildingDisplay : MonoBehaviour {

    public bool build = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseExit()
    {
     //   Destroy(this.gameObject);
    }

    // The display for where to place a booster
    // Once the spot has been picked another script grabs the build bool and this object destroys itself
    void OnMouseEnter()
    {
        if(Input.GetMouseButtonDown(0))
        {
            build = true;
            Destroy(this.gameObject);
        }
    }
}
