using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour
{
    public GameObject player;
    public TrashBinLid trashBinLid;
    public float collisionDistance = 2f;

    void Start()
    {
        trashBinLid = GetComponentInChildren<TrashBinLid>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player && trashBinLid)
        {
            if(Vector3.Distance(transform.position, player.transform.position) < collisionDistance)
            {
                Debug.Log("Player collided with trash bin!");
                trashBinLid.isOpen = true;
            }
            else
                trashBinLid.isOpen = false;
        }
    }
}
