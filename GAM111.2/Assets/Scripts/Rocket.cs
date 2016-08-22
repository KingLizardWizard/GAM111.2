using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

    GameController gameController;


    public GameObject thrusterButton;
    public GameObject BaseButton;
    public GameObject TopButton;

    public GameObject thrusters;
    public GameObject baseObject;
    public GameObject top;

    public int ThrustersWoodPrice;
    public int ThrustersMetalPrice;
    public int BaseWoodPrice;
    public int BaseMetalPrice;
    public int TopWoodPrice;
    public int TopMetalPrice;

    public float timer;

    public bool factory;
    public bool powerPlant;
    public bool win;

    // Use this for initialization
    void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        BaseButton.gameObject.SetActive(false);
        TopButton.gameObject.SetActive(false);
        thrusterButton.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if(factory == true && powerPlant == true)
        {
            thrusterButton.gameObject.SetActive(true);
        }
        if(win == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Application.LoadLevel("Winner");
            }
        }
	}

    public void BuildThrusters()
    {
        if (gameController.wood > ThrustersWoodPrice && gameController.metal > ThrustersMetalPrice)
        {
            gameController.metal -= BaseMetalPrice;
            gameController.wood -= BaseWoodPrice;
            Instantiate(thrusters, transform.position, transform.rotation);
            BaseButton.gameObject.SetActive(true);
        }
    }

    public void BuildBase()
    {
        if (gameController.wood > BaseWoodPrice && gameController.metal > BaseMetalPrice)
        {
            gameController.metal -= BaseMetalPrice;
            gameController.wood -= BaseWoodPrice;
            Instantiate(baseObject, transform.position, transform.rotation);
            TopButton.gameObject.SetActive(true);
        }
    }

    public void BuildTop()
    {
        if (gameController.wood > TopWoodPrice && gameController.metal > TopMetalPrice)
        {
            gameController.metal -= BaseMetalPrice;
            gameController.wood -= BaseWoodPrice;
            Instantiate(top, transform.position, transform.rotation);
            win = true;
        }
    }
}
