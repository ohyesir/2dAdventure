using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public ItemImageUI itemImageUI;
    public int currentImageIndex;//当前索引
    public int gotImageIndex;//获取到的一共索引
  

    private void Awake() 
    {
        currentImageIndex = -1;
        gotImageIndex = -1;
    }
    
    private void OnEnable() {
        EventHandler.UpdateItemUIEvent += OnUpdateItemUI;
        EventHandler.SetItemIndexEvent += OnSetItemIndex;
        EventHandler.SwitchItemEvent += SwitchItem;
        EventHandler.UseItemEvent += UseItem;
    }

    private void OnSetItemIndex(int index)
    {
        gotImageIndex = index;
    }

    private void OnUpdateItemUI(ItemData itemData, int index)
    {
        if (itemData == null)
        {
            // Debug.Log("itemData is null");
            itemImageUI.SetEmpty();
            currentImageIndex = -1;
            gotImageIndex = -1;
        }
        else
        {
            itemImageUI.SetItem(itemData);
            currentImageIndex = index; //保持索引不变
            
        }
    }

    private void SwitchItem(int arg)
    {   
        if(gotImageIndex+1 >= 1)
        {
            currentImageIndex += arg;
            if(currentImageIndex < 0)
            {
                currentImageIndex = gotImageIndex; //队头到队尾
                EventHandler.RaiseUpdateItemIndex(currentImageIndex);
            }
            else if(currentImageIndex > gotImageIndex)
            {
                currentImageIndex = 0; //队尾到队头
                EventHandler.RaiseUpdateItemIndex(currentImageIndex);
            }
            else 
            {
                EventHandler.RaiseUpdateItemIndex(currentImageIndex);
            }
        }
        
    }

    private void UseItem()
    {
        // Debug.Log("UseItem");
        if(gotImageIndex+1 >= 1) //当物品栏有东西时
            EventHandler.RemoveItem(currentImageIndex);

        
    }

    private void OnDisable() {
        EventHandler.UpdateItemUIEvent -= OnUpdateItemUI;
        EventHandler.SetItemIndexEvent -= OnSetItemIndex;
        EventHandler.SwitchItemEvent -= SwitchItem;
        EventHandler.UseItemEvent -= UseItem;
    }
    
    
}
