using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileSlot : MonoBehaviour, IPointerDownHandler
{
    private TileData _tile;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Click");
    }
}
