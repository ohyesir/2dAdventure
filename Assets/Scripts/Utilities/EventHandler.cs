using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventHandler
{
    public static event System.Action<ItemData, int> UpdateItemUIEvent; //传递更新UI的数据通知
    public static void RaiseUpdateUI(ItemData itemData, int index)
    {
        UpdateItemUIEvent?.Invoke(itemData, index); 
    }

    public static event System.Action<int> SetItemIndexEvent; //Item -> UI传递设置列表中当前最大索引
    public static void RaiseSetItemIndex(int index)
    {
        SetItemIndexEvent?.Invoke(index); 
    }

    public static event System.Action<int> UpdateItemIndexEvent;
    public static void RaiseUpdateItemIndex(int index)
    {
        UpdateItemIndexEvent?.Invoke(index); //UI -> Item传递当前索引用于更新道具
    }

    public static event System.Action<int> SwitchItemEvent;
    public static void RaiseSwitchItem(int index)
    {
        SwitchItemEvent?.Invoke(index); //PlayerControl -> Ui传递切换道具
    }

    public static event System.Action UseItemEvent;
    public static void RaiseUseItem()
    {
        UseItemEvent?.Invoke(); //PlayerControl -> Item发起消耗道具事件
    }

    public static event System.Action<int> RemoveItemEvent;
    public static void RemoveItem(int index)
    {
        RemoveItemEvent?.Invoke(index); //PlayerControl -> Ui传递切换道具
    }

    public static event System.Action<ItemName> ItemEffectEvent;
    public static void RaiseItemEffect(ItemName itemName)
    {
        ItemEffectEvent?.Invoke(itemName);
    }

    
    
    
    
        
    
    

    

    
    
}
