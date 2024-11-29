using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    private Rigidbody rb;
    private Transform playerTrans;
    private PlayerInputControl playerInputControl;
    private float movementX; 
    
    [SerializeField] float maxSpeed;
    [SerializeField] float currentSpeed;
    [SerializeField] float acceleration;
    [SerializeField] float changeForce;
    [SerializeField] int maxItemBox;
    // [Header("Color")]
    // public Material orinMaterial; 
    // public Material tempMaterial;


    [Header("Score")]
    public int score;
    public TextMeshProUGUI textMeshProUGUI;

    [Header("EndGame")]
    public GameObject endGame;

    void Awake()
    {
        playerTrans = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        playerInputControl = new PlayerInputControl();
        
        playerInputControl.Player.SwitchItemToLeft.started += ctx =>
        {
            EventHandler.RaiseSwitchItem(1); //实现序号+1
        };

        playerInputControl.Player.SwitchItemToRight.started += ctx =>
        {
            EventHandler.RaiseSwitchItem(-1);
        };

        playerInputControl.Player.UseItem.started += ctx =>
        {
            EventHandler.RaiseUseItem(); //实现使用物品
        };
        
        // playerInputControl.Player.SwitchItem.started += GetInput;
    }

    // private void GetInput(InputAction.CallbackContext context)
    // {
    //     throw new NotImplementedException();
    // }

    private void Start()
    {
        playerInputControl.Player.Enable();
    }
    public void InitialGame(float maxSpeed, float acceleration, float changeForce, int maxItemBox)
    {
        this.maxSpeed = maxSpeed;
        this.acceleration = acceleration;
        this.changeForce = changeForce;
        this.maxItemBox = maxItemBox;
        score = 0;
        endGame.SetActive(false);
        
    }

    
    
    private void Update()
    {
        GetInputDirection();
    }
    
    private void FixedUpdate() 
    {
        StartEngine();
        
        // Debug.Log("accurate");
    }

    private void StartEngine()
    {
        if(currentSpeed < maxSpeed)
        {
            currentSpeed += acceleration * Time.deltaTime;
    
            
        }

        rb.AddForce(new Vector3(movementX * changeForce,0, acceleration * Time.deltaTime)); //改变物体方向
    }
    
    void GetInputDirection()
    {
       
        Vector2 movementVector = playerInputControl.Player.Move.ReadValue<Vector2>();
        
        // Vector2 movementVector = inputValue.Get<Vector2>();
        movementX = movementVector.x;
        // Debug.Log(movementX);
    }

    // void OnMove(InputValue inputValue)
    // {
    //     Vector2 movementVector = inputValue.Get<Vector2>();
    //     movementX = movementVector.x;
    //     Debug.Log(movementX);
    // }

    
    private void OnEnable() 
    {
        
    }

    private void OnDisable() 
    {
        
    }
    
 
    private void OnTriggerStay(Collider other)
    {
        // Debug.Log("trigger");
        if(other.gameObject.CompareTag("Item") || other.gameObject.CompareTag("CheckColor"))
        {
            other.GetComponent<ITriggerObject>().TriggerAciton(); //触发效果
            // score++;
            // textMeshProUGUI.text = score.ToString();
            // EndGame();
            
        }   
    }
    
    

    // private void ChangeColor(Collider other)
    // {
    //     tempMaterial = other.gameObject.GetComponent<Renderer>().material;
    //     GetComponent<Renderer>().material = tempMaterial;
    //     float timeCounter = 10.0f;
    //     if(timeCounter > 0.0f)
    //     {
    //         StartCoroutine(CountChangeColor(timeCounter));
    //     }
        
        
        
    // }

    // IEnumerator CountChangeColor(float timeCounter)
    // {
    //     yield return new WaitForSeconds(timeCounter);
    //     GetComponent<Renderer>().material = orinMaterial;
    // }

    
    private void EndGame()
    {
       
        if(score >= 4)
        {
           
            endGame.SetActive(true);
        }
    }
}

