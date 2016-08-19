using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI : MonoBehaviour {
    public GameObject houseMenu;
    GameController gameController;

    private bool isShowing;

    public Text woodText;

    public int woodUI;

    // Use this for initialization 
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        SetWoodText();
        houseMenu.SetActive(isShowing);
    }

    // Update is called once per frame
    void Update()
    {
        woodText.text = "Wood: " + woodUI.ToString();
        woodUI = gameController.wood;
        if(Input.GetMouseButtonDown(0))
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

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isShowing = !isShowing;
            houseMenu.SetActive(isShowing);
        }
    }

    void SetWoodText()
    {
        
    }
}
