using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ItemListSO", menuName = "SO/DataSO/ItemListSO", order = 0)]
public class ItemDataListSO : ScriptableObject 
{
    public List<ItemData> itemList;
    
    public ItemData GetItemData(ItemName itemName)
    {
        return itemList.Find(item => item.itemName == itemName);
    }
}

[System.Serializable]
public class ItemData
{
    public ItemName itemName;
    public Sprite itemSprite;
    public override string ToString() => itemName.ToString();
}