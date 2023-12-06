using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tile")]
public class TileData : ScriptableObject
{
    public List<Interaction> interactions;

    public RuleTile ruleTile;

    public Sprite baseSprite;
    public Sprite squareTopLeftSprite;
    public Sprite squareTopSprite;
    public Sprite squareTopRightSprite;
    public Sprite vLineTopSprite;
    public Sprite squareLeftSprite;
    public Sprite squareMiddleSprite;
    public Sprite squareRightSprite;
    public Sprite vLineMiddleSprite;
    public Sprite squareBottomLeftSprite;
    public Sprite squareBottomSprite;
    public Sprite squareBottomRightSprite;
    public Sprite vLineBottomSprite;
    public Sprite hLineLeftSprite;
    public Sprite hLineMiddleSprite;
    public Sprite hLineRightSprite;
}
