using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemImageUI : MonoBehaviour
{
    public Image currentImage;
    // private ItemData currentItemData;
    // private bool isSelected;

    public void SetItem(ItemData itemData)
    {
        // currentItemData = itemData;
        gameObject.SetActive(true);
        currentImage.sprite = itemData.itemSprite;
        // isSelected = false;
        
    }
    
    public void SetEmpty()
    {
        gameObject.SetActive(false);
    }
    
}
