using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour
{
    public GameObject player;
    public TrashBinLid trashBinLid;
    public TrashType trashType;
    public float collisionDistance = 2f;
    public bool isLeft = false;
    float yAngle;

    void Start()
    {
        trashBinLid = GetComponentInChildren<TrashBinLid>();
        yAngle = isLeft ? 270f : 90f;
        transform.rotation = Quaternion.Euler(0, yAngle, 0);
        trashBinLid.Init(yAngle);    
    }

    void Update()
    {
        if(player && trashBinLid)
        {
            if(Vector3.Distance(transform.position, player.transform.position) < collisionDistance)
            {
                // Debug.Log("Player collided with trash bin!");
                trashBinLid.isOpen = true;  
            }
            else
                trashBinLid.isOpen = false;
        }
    }

    
}
