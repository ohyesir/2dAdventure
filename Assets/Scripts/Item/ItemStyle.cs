using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStyle : MonoBehaviour
{
    private Transform trans;
    private void Start() 
    {
        trans = GetComponent<Transform>();
        
    }

    private void Update() {
        trans.Rotate(new Vector3(0, 90, 0) * Time.deltaTime, Space.World); //默认是sqace.self以自身坐标轴旋转

    }

}
