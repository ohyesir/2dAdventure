using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    private void Start() 
    {
        offset = transform.position - player.transform.position; //获得摄像机与玩家之间的距离
    }

    private void LateUpdate() //在其他update执行完后执行的update
    {
        transform.position = player.transform.position + offset; //摄像机跟随玩家
    }
}
