using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface ISelectable 
{
    bool OnSelect(SelectedTileDisplay selectedTile);
}
