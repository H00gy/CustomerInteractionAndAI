using UnityEngine;
using System.Collections.Generic;
public class authenticityChecker : MonoBehaviour
{
    [Header("list of known items")]
    public List<ItemBrandData> itemBrands;
    public float price;
    /*
         * this isn't actually authenticating anything, I just need the structure 
         * to be the same as my actual project in order to set the price 
     */
    public void checkAuthenticity(ItemInstance item)
    {
        if (item == null) {
            Debug.Log("item ref null");
            return;
        }
        if (item.shapeP == null || item.shapeP.sr == null) {
            Debug.Log("Logo or sr missing");
            return;
        }
        if (itemBrands == null || itemBrands.Count == 0)
        {
            Debug.Log("no brands assigned");
            return;
        }
        // confirmation of the shapes in the list 
        foreach(var itemBrand in itemBrands)
        {
            Debug.Log($"Known shape: {itemBrand.objectShape}");
        }

        Sprite shapeSprite = item.shapeP.sr.sprite;
        if (shapeSprite != null )
        {
            Debug.Log(item.name + " sprite missing");
            return;
        }
        Debug.Log($"[AuthChecker] Checking authenticity for {item.name} | Sprite: {shapeSprite.name}");
        string shapeName = NormalizeSpriteName(shapeSprite.name);

        // Try to find a matching brand
        var foundBrand = itemBrands.Find(b =>
            b != null &&
            b.objectShape != null &&
            (b.objectShape == shapeSprite ||
             NormalizeSpriteName(b.objectShape.name) == shapeName)
        );

        if (foundBrand == null)
        {
            Debug.Log("uknown brand");
            return;
        }

        bool result = isAuthentic(item, foundBrand);
        Debug.Log($"[Authchecker] authenticity result for {item.name}: {(result ? "REAL" : "FAKE")}");

    }

    public bool isAuthentic(ItemInstance item, ItemBrandData brand)
    {
        Sprite shapeSprite = item.shapeP?.sr?.sprite;
        price = Random.Range(brand.priceRange.x, brand.priceRange.y);
        Debug.Log("This items Price is " + price);
        return true;
        
    }


    private string NormalizeSpriteName(string name)
    {
        if (string.IsNullOrEmpty(name)) return "";
        return name.Replace("(Clone)", "").Trim().ToLowerInvariant();

    }
}
