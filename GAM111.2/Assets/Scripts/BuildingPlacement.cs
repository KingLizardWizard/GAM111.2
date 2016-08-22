using UnityEngine;
using System.Collections;

public class BuildingPlacement : MonoBehaviour {

    protected SelectionManager selectionManager;

    public GameObject BuildingPrefab;

    public Material InvalidMaterial;
    public Material ValidMaterial;

    public MeshRenderer meshRenderer;
    private bool canPlace = true;

    // Use this for initialization
    void Start()
    {
        selectionManager = FindObjectOfType<SelectionManager>();
        meshRenderer.material = ValidMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        // is the selection manager in placement mode?
        if (selectionManager.inPlacementMode)
        {
            // move the building to the mouse location
            transform.position = selectionManager.mousePosition;

            if (canPlace && Input.GetMouseButtonDown(0))
            {
                // create the actual building
                Instantiate(BuildingPrefab, transform.position, transform.rotation);

                // disable placement mode
                selectionManager.inPlacementMode = false;

                // destroy the placement building
                Destroy(gameObject);
            }
        }
    }

    // if there is another player or building in the objects path, make it unable to place structures
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Building"))
        {
            canPlace = false;
            meshRenderer.material = InvalidMaterial;
        }
    }


    // Once the structures leaves the objects path, make it able to place structures
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Building"))
        {
            canPlace = true;
            meshRenderer.material = ValidMaterial;
        }
    }
}
