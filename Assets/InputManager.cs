using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int toolsIndex = 0;
    public GameObject[] tools;

    public Transform leftHand;
    public Transform rightHand;

    private GameObject currentHand;
    private float timer = 0f;
    public float spawnInterval = 2f;


    void Start()
    {
        currentHand = Instantiate(tools[toolsIndex], rightHand);
        toolsIndex++;
    }

    // Update is called once per frame
    void Update()
    {
//        timer += Time.deltaTime;

        if (OVRInput.GetUp(OVRInput.Button.One))
        {
            Debug.Log("Change!");
            ChangeTool();
            timer = 0f;
        }

        if (timer >= spawnInterval)
        {
            Debug.Log("Change!");
            ChangeTool();
            timer = 0f;
        }
    }

    void ChangeTool()
    {
        Debug.Log(toolsIndex);
        Destroy(currentHand);
        currentHand = Instantiate(tools[toolsIndex], leftHand);
        toolsIndex++;
        toolsIndex = toolsIndex % tools.Length;
    }
}
