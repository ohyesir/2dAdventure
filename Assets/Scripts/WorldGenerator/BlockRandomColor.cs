using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRandomColor : MonoBehaviour
{
    [SerializeField]  private Material[] materialList;
    
    
    void Start()
    {
        //随机颜色
        int index = Random.Range(0, materialList.Length);
        Material material= materialList[index];
        GetComponent<Renderer>().material = material;
    }

    
}
