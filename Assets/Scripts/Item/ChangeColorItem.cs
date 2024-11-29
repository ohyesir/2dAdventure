using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColorItem : MonoBehaviour,ITriggerObject
{
   [SerializeField]private ItemName itemName;
   // [SerializeField]private string itemDescription;

   public void TriggerAciton()
   {
      ItemManager.instance.AddItem(itemName);
      Destroy(gameObject);
   }
   
   // public void ItemEffect()
   // {
   //    Material newMaterial = GetComponent<Renderer>().material; //获取自身material
   //    FindObjectOfType<PlayerItemEffects>().ChangeColor(newMaterial);
      
      
   // }

    
}
