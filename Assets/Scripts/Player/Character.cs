using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] float maxSpeed; //最大速度
    [SerializeField] float acceleration;//加速度
    [SerializeField] float changeForce;//变向力大小
    [SerializeField] int maxItemBox;//最大持有道具数量
    
    private PlayerController playerController;
    private void Awake() 
    {
        playerController = GetComponent<PlayerController>();
        
    }

    private void Start() 
    {
        //选完角色后，初始化角色信息开始游戏
        playerController.InitialGame(maxSpeed, acceleration, changeForce, maxItemBox);
    }
}
