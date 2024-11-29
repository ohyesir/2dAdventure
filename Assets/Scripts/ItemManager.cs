using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;
    [SerializeField] List<ItemName> itemList = new List<ItemName>();
    
    public ItemDataListSO itemDataListSO;
    

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
        
        
    }



    public void AddItem(ItemName itemName)
    {
        if (!itemList.Contains(itemName))
            {
                itemList.Add(itemName);
                
                
                if(itemList.Count == 1) // first item
                {
                    ItemData itemData = itemDataListSO.GetItemData(itemName);
                    EventHandler.RaiseUpdateUI(itemData, itemList.Count - 1);
                }

                EventHandler.RaiseSetItemIndex(itemList.Count - 1);//传递最高索引
                    
            }
    }
    
    

    

    private void OnEnable() {
        EventHandler.UpdateItemIndexEvent += OnUpdateItemIndex;
        EventHandler.RemoveItemEvent += RemoveItem;
    }

    private void OnUpdateItemIndex(int index)
    {
        ItemData itemData = itemDataListSO.GetItemData(itemList[index]);
        EventHandler.RaiseUpdateUI(itemData, index); //收到UIManager的通知后刷新UI
    }

    public void RemoveItem(int index)
    {
        Debug.Log("道具名" + itemList[index]);
        EventHandler.RaiseItemEffect(itemList[index]);
        
        if(itemList.Count > 1)
        {
            // Debug.Log("RemoveItem");
            itemList.RemoveAt(index);
            int nextIndex;
            if(index != 0)
            {
                nextIndex = index - 1;//下一个显示的是前一个
                ItemData itemData = itemDataListSO.GetItemData(itemList[nextIndex]);//刷新前一个
                EventHandler.RaiseUpdateUI(itemData, nextIndex);
            }  
            else
            {
                nextIndex = 0;//下一个列表元素序号自动为0
                ItemData itemData = itemDataListSO.GetItemData(itemList[nextIndex]);
                EventHandler.RaiseUpdateUI(itemData, nextIndex);
            }
            EventHandler.RaiseSetItemIndex(itemList.Count - 1);//传递最高索引 
            
        }
        else if( itemList.Count == 1)
        {
            itemList.Clear();
            ItemData itemData = null;
            EventHandler.RaiseUpdateUI(itemData, index);
        }
            
            

    }
    
    private void OnDisable() {
        EventHandler.UpdateItemIndexEvent -= OnUpdateItemIndex;
        EventHandler.RemoveItemEvent -= RemoveItem;
    }
}
