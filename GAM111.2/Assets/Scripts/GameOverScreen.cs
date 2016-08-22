using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Uses for a button to go back to main menu
    public void ReturnToTitle()
    {
        Application.LoadLevel("MainMenu");
    }
}
