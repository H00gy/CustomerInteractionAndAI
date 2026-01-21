using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BrandData", menuName = "brands/BrandData")]
public class ItemBrandData : ScriptableObject
{
    public Sprite objectShape;
    public Vector2 priceRange; 
}
