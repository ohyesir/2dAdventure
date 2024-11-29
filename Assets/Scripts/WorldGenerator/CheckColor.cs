using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckColor : MonoBehaviour, ITriggerObject
{
    public void TriggerAciton()
    {
        // Debug.Log("check");
        Material blockMa = GetComponentInParent<Renderer>().material;
        Material playerMa = FindObjectOfType<PlayerItemEffects>().GetComponent<Renderer>().material;
        // Debug.Log("blockMa"+blockMa.name);
        // Debug.Log("playerMa"+playerMa.name);
        if(playerMa.name == blockMa.name)
        //判断玩家颜色和block颜色
        {
            // Debug.Log("boom");
            transform.parent.gameObject.SetActive(false);//销毁
        }
         
    }

    
}
