using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scissors : MonoBehaviour
{
    public GameObject leftPart;
    public GameObject rightPart;
    public Trash TrashObject;    // 쓰래기 오브젝트를 가위와 연동할 로직이 필요함
    private float yAngle = 0f;
    public float rotationSpeed = 90;
    public bool bAction;
    public float rotationAngle = 30;
    public float rotationDuration = 1f;
    private float timer = 0f;
    void Start()
    {
        bAction = false;
    }

    void Update()
    {
        if(bAction == true)
        {
            timer += Time.deltaTime;
        }
        else if(timer > rotationDuration)
        {
            bAction = false;
            timer = 0f;
        }

        if(bAction)
        {
            RemoveAction();
        }
        else if(yAngle != 0f)
        {
            yAngle = 0f;
            leftPart.transform.rotation = Quaternion.Euler(0, 0, 0);
            rightPart.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void RemoveAction()
    {
        // 쓰래기 오브젝트 라벨 없는 버전으로 바꿈
        if(TrashObject && TrashObject.bChanged == false)
        {
            TrashObject.bChanged = true;
            TrashObject.ChangeMesh();
        }

        yAngle += Time.deltaTime * rotationSpeed;
        if(yAngle > rotationAngle*2)
        {
            yAngle -= rotationAngle*2;
        }

        leftPart.transform.rotation = Quaternion.Euler(0, Mathf.Min(yAngle, rotationAngle*2-yAngle), 0);
        rightPart.transform.rotation = Quaternion.Euler(0, -Mathf.Min(yAngle, rotationAngle*2-yAngle), 0);
    }
}
