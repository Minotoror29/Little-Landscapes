using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private LayerMask selectableLayer;
    [SerializeField] private LayerMask droppableLayer;
    [SerializeField] private SelectedTileDisplay selectedTileDisplay;

    private void Start()
    {
        selectedTileDisplay.Initialize();
    }

    public void UpdateLogic()
    {
        selectedTileDisplay.UpdateLogic();

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 100f, selectableLayer);
            if (hit)
            {
                hit.transform.GetComponent<ISelectable>().OnSelect(selectedTileDisplay);
            }
        } else if (Input.GetMouseButtonUp(0))
        {
            if (selectedTileDisplay.SelectedTile == null) return;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 100f, droppableLayer);
            if (hit)
            {
                if (!hit.transform.GetComponent<ISelectable>().OnSelect(selectedTileDisplay))
                {
                    selectedTileDisplay.PutBackTile();
                }
            } else
            {
                selectedTileDisplay.PutBackTile();
            }
        }
    }
}
