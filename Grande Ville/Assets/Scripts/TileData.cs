using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tile")]
public class TileData : ScriptableObject
{
    public Sprite sprite;
    public int score;
    public List<Interaction> interactions;
}
