using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Button commands to change the scene depending on the button pressed
    public void LoadLevel()
    {
        Application.LoadLevel("Main");
    }

    public void LoadMenu()
    {
        Application.LoadLevel("MainMenu");
    }

    public void LoadHowToPlay()
    {
        Application.LoadLevel("HowToPlay");
    }
}
