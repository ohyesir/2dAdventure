using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    [SerializeField] Transform startPoint;
    [SerializeField] Transform endPoint;
    [SerializeField] GameObject[] roadBlocks; //存放地形数组

    private void Start()
    {
        GenerateWorld();
    }
    
    private void GenerateWorld()
    {
        Vector3 nextBlockPosition = startPoint.position;
        int pickBlocksIndexOld = -1;
        float EndPointDistance = Vector3.Distance(startPoint.position, endPoint.position); 
         
        while(Vector3.Distance(startPoint.position, nextBlockPosition) < EndPointDistance)
        {
            // int i = 1; //循环内创建的参数寿命只在循环中
            int pickBlocksIndexNew = Random.Range(0, roadBlocks.Length);//随机选择一个roadBlocks数组索引
            
            while(pickBlocksIndexNew == pickBlocksIndexOld)
            {
                pickBlocksIndexNew = Random.Range(0, roadBlocks.Length);
            }
                
            GameObject pickBlocks = roadBlocks[pickBlocksIndexNew]; //根据索引获取roadBlocks数组中的元素
            GameObject newBlock = Instantiate(pickBlocks, nextBlockPosition, Quaternion.identity);
            float blockLength = newBlock.GetComponentInChildren<Renderer>().bounds.size.z; //获取路障Z轴大小
            nextBlockPosition += (endPoint.position - startPoint.position).normalized * blockLength / 2;
            
            pickBlocksIndexOld = pickBlocksIndexNew;
            // i += 1;
            
            
        } 

        // Vector3 nextBlockPosition = startPoint.position;
        // float EndPointDistance = Vector3.Distance(startPoint.position, endPoint.position);  
        // var usedIndices = new HashSet<int>();  // 记录已使用的索引

        // while(Vector3.Distance(startPoint.position, nextBlockPosition) < EndPointDistance)
        // {
        //     int pickBlocksIndexNew;
        //     do
        //     {
        //         pickBlocksIndexNew = Random.Range(0, roadBlocks.Length);
        //     }
        //     while(usedIndices.Contains(pickBlocksIndexNew) );
        //     // || usedIndices.Count >= roadBlocks.Length

        //     usedIndices.Add(pickBlocksIndexNew);使用hashet记录已经用过的标签
        //     if(usedIndices.Count == 3)
        //         usedIndices.Clear();

        //     GameObject pickBlocks = roadBlocks[pickBlocksIndexNew]; // 根据索引获取roadBlocks数组中的元素
        //     GameObject newBlock = Instantiate(pickBlocks, nextBlockPosition, Quaternion.identity);
        //     float blockLength = newBlock.GetComponentInChildren<Renderer>().bounds.size.z; // 获取路障Z轴大小
        //     nextBlockPosition += (endPoint.position - startPoint.position).normalized * blockLength / 2;
        // }
    }
}
