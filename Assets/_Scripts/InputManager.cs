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
    public GameManager gm;

    private GameObject currentHand;
    private GameObject grabedObject = null;
    private float timer = 0f;
    public float spawnInterval = 2f;
    public float collisionDistance = 0.3f;


    void Start()
    {
        currentHand = Instantiate(tools[toolsIndex], leftHand);
        currentHand.transform.localPosition = new Vector3(0, 0, 0);
        NextTool();
    }


    // Update is called once per frame
    void Update()
    {
        //timer += Time.deltaTime;

        if (IsRightHandGrab())
        {
            gm.setTrashImage(grabedObject.GetComponent<Trash>().trashType);
        }
        
        if (OVRInput.GetUp(OVRInput.Button.One))
        {
            //Debug.Log("Change!");
            ChangeTool();
            //timer = 0f;
        }

        if (OVRInput.GetUp(OVRInput.Button.Two))
        {
            //Debug.Log("Change!");
            ChangeToolReverse();
        }

        if (OVRInput.GetUp(OVRInput.Button.Three))
        {
            //Debug.Log("Change!");
            ScissorMove();
        }

        /*
        if (timer >= spawnInterval)
        {
            //Debug.Log("Change!");
            ChangeTool();
            timer = 0f;
        }
        */
    }

    bool IsRightHandGrab()
    {
        GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
        List<GameObject> trashes = new List<GameObject>();
        // 모든 GameObject를 검사하여 스크립트가 있는지 확인합니다.
        foreach (GameObject obj in objects)
        {
            OVRGrabbable script = obj.GetComponent<OVRGrabbable>();
            if (script != null)
            {
                // 스크립트를 찾았으면 해당 GameObject를 반환합니다.
                trashes.Add(obj);
            }
        }

        GameObject nearest = null;
        float min_distance = Mathf.Infinity;
        foreach (GameObject obj in trashes)
        {
            float distance = Vector3.Distance(obj.transform.position, rightHand.transform.position);
            if (min_distance > distance)
            {
                min_distance = distance;
                nearest = obj;
            }
        }

        //Debug.Log(min_distance);
        if(min_distance < collisionDistance)
        {
            grabedObject = nearest;
            return true;
        }
        else
        {
            return false;
        }
    }
    void NextTool()
    {
        toolsIndex++;
        toolsIndex = toolsIndex % tools.Length;
    }

    void ScissorMove()
    {
        //int currentIndex = (toolsIndex - 1) % tools.Length;
        Scissors scissor = currentHand.GetComponent<Scissors>();
        if (scissor != null)
        {
            //gm.spawnInterval = 1;
            scissor.bAction = true;
        }
    }

    void ChangeTool()
    {
        //Debug.Log(toolsIndex);
        Destroy(currentHand);
        currentHand = Instantiate(tools[toolsIndex], leftHand);
        currentHand.transform.localPosition = new Vector3(0, 0, 0);
        NextTool();
    }

    void ChangeToolReverse()
    {
        //Debug.Log(toolsIndex);
        Destroy(currentHand);
        toolsIndex = (toolsIndex - 2) % tools.Length;
        currentHand = Instantiate(tools[toolsIndex], leftHand);
        currentHand.transform.localPosition = new Vector3(0, 0, 0);
        NextTool();
    }
}
