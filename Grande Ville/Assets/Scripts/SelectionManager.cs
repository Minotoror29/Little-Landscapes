using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private LayerMask selectableLayer;

    private void Update()
    {
        UpdateLogic();
    }

    public void UpdateLogic()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics2D.Raycast(ray.origin, ray.direction, 100f, selectableLayer))
            {
                Debug.Log("hit");
            }
        }
    }
}
