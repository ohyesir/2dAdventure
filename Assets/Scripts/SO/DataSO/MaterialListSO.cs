using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MaterialListSO", menuName = "SO/DataSO/MaterialListSO", order = 0)]
public class MaterialListSO : ScriptableObject
{
    public List<ItemEffect> materialList;
    public ItemEffect GetMaterial(ItemName itemName)
    {
        return materialList.Find(x => x.itemName == itemName);
    }

    [System.Serializable]
    public class ItemEffect
    {
        public ItemName itemName;
        public Material material;
    }
}
