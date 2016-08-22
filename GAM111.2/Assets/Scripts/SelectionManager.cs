using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectionManager : MonoBehaviour {
    public GameObject selectionTriggerPrefab;

    GameController gameController;

    // Lists
    public List<GameObject> selectedUnits = new List<GameObject>();
    // Bools
    public bool isSelecting = false;
    public bool inPlacementMode = false;
    public bool mousePositionValid = false;
    // V3's
    public Vector3 mousePosition; // position in world space
    public Vector3 mousePositionA;
    public Vector3 mousePositionB;

    // Use this for initialization
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

    }

    void Update_MousePosition()
    {
        // Construct a ray based on the mouse location
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Raycast against the world to see if we hit anything
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            mousePosition = hit.point;
            mousePositionValid = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Only update if either mouse button is down
        // OR if we're in placement mode
        mousePositionValid = false;
        if (inPlacementMode || Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            Update_MousePosition();
        }

        if (inPlacementMode)
        {

        } // not in placement mode, allow selecting
        else
        {
            // Left click?
            if (Input.GetMouseButtonDown(0))
            {
                if (isSelecting == false)
                {
                    // put us into selection mode
                    isSelecting = true;

                    // store the mouse location
                    mousePositionA = mousePositionB = mousePosition;

                    // create the selection trigger
                    GameObject selectionTrigger = Instantiate(selectionTriggerPrefab,
                                                              mousePositionA,
                                                              transform.rotation) as GameObject;
                    selectionTrigger.GetComponent<SelectionTrigger>().mousePositionA = mousePositionA;
                    selectionTrigger.GetComponent<SelectionTrigger>().mousePositionB = mousePositionB;
                }
            }

            // Right click?
            if (Input.GetMouseButton(1))
            {
                foreach (GameObject unit in selectedUnits)
                {
                    unit.GetComponent<Villager>().MoveTo(mousePosition);
                }
            }
        }
    }

    public void PlaceBuilding(GameObject placementPrefab)
    {
        // Tests if in placement mode and if there are enough resources to build the booster
        if (!inPlacementMode && gameController.metal > gameController.boosterMetalCost & gameController.wood > gameController.boosterWoodCost)
        {
            // minus the resources used to build the booster
            gameController.metal -= gameController.boosterMetalCost;
            gameController.wood -= gameController.boosterWoodCost;
            // put us in placement mode
            inPlacementMode = true;

            // wipe the selected units
            selectedUnits.Clear();

            // force an update of the mouse position
            Update_MousePosition();

            // create our placement prefab
            GameObject placementObj = Instantiate(placementPrefab, mousePosition, transform.rotation) as GameObject;
        }
        else
        {

        }
    }
}
