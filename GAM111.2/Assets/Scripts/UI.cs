using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI : MonoBehaviour {
    public GameObject houseMenu;
    GameController gameController;

    public bool isShowing;

    public Text woodText;
    // public Text energyText;
    public Text metalText;
    public Slider healthText;

    public int woodUI;
    public float energyUI;
    public int metalUI;

    // Use this for initialization 
    void Start()
    {
        houseMenu.SetActive(isShowing);
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        SetText();
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "House")
                {
                    isShowing = !isShowing;
                    houseMenu.SetActive(isShowing);
                }
            }
        }

    }



    void SetText()
    {
        woodText.text = "Wood: " + woodUI.ToString();
        woodUI = gameController.wood;
        // energyText.text = "Energy: " + energyUI.ToString("f0");
        // energyUI = gameController.energy;
        metalText.text = "Metal: " + metalUI.ToString();
        metalUI = gameController.metal;
        healthText.value = gameController.energy;

    }
}
