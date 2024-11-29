using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemEffects : MonoBehaviour
{
    public MaterialListSO materialListSO; 

    private void OnEnable() 
    {
        EventHandler.ItemEffectEvent += ItemIndent;
    }

    private void ItemIndent(ItemName itemName)
    {
        
        switch (itemName)
        {
            case ItemName.ChangeGreen:ChangeColor(itemName);
                break;
            case ItemName.ChangeRed:ChangeColor(itemName);
                break;
            case ItemName.ChangeWhite:ChangeColor(itemName);
                break;
            case ItemName.ChangeYellow:ChangeColor(itemName);
                break;
            default:
                break;
        }
    }

    private void OnDisable() 
    {
        EventHandler.ItemEffectEvent -= ItemIndent;
    }  
    private void ChangeColor(ItemName color)
    {

        Material newMaterial = materialListSO.GetMaterial(color).material;
        GetComponent<Renderer>().material = newMaterial;
    }

    
}
