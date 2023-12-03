using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface ISelectable 
{
    void OnSelect(SelectedTileDisplay selectedTile);
}
