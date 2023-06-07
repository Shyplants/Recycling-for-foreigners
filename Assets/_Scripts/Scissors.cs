using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scissors : MonoBehaviour
{
    public GameObject leftPart;
    public GameObject rightPart;
    public Trash TrashObject;    // 쓰래기 오브젝트를 가위와 연동할 로직이 필요함
    public AudioClip soundClip;
    public AudioClip wrongClip;
    private AudioSource audioSource;
    private float yAngle = 0f;
    public float rotationSpeed = 90;
    public bool bAction;
    public float rotationAngle = 30;
    public float rotationDuration = 2f;    // 비율 2(시간) : 3(가위질)
    private float timer = 0f;
    void Start()
    {
        bAction = false;
        audioSource = GetComponent<AudioSource>();
    }

    void FindNearestTarget()
    {
        GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
        List<GameObject> trashes = new List<GameObject>();
        // 모든 GameObject를 검사하여 스크립트가 있는지 확인합니다.
        foreach (GameObject obj in objects)
        {
            Trash script = obj.GetComponent<Trash>();
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
            float distance = Vector3.Distance(obj.transform.position, transform.position);
            if (min_distance > distance)
            {
                min_distance = distance;
                nearest = obj;
            }
        }

        TrashObject = nearest.GetComponent<Trash>();
    }
    void Update()
    {
        if(bAction == true)
        {
            timer += Time.deltaTime;
            if (timer > rotationDuration)
            {
                bAction = false;
                timer = 0f;
            }
        }

        if(bAction)
        {
            RemoveAction();
        }
        else if(yAngle != 0f)
        {
            yAngle = 0f;
            leftPart.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            rightPart.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    public void RemoveAction()
    {
        // 가장 가까운 오브젝트 찾음!
        FindNearestTarget();

        // 쓰래기 오브젝트 라벨 없는 버전으로 바꿈
        if (TrashObject && (TrashObject.bChanged == false))
        {
            Debug.Log(TrashObject);
            PlayAudioClip(soundClip);
            TrashObject.bChanged = true;
            TrashObject.ChangeMesh();
        }

        // 올바르지 않은경우(쓰레기 오브젝트 X or 이미 변경된 상태)
        // Sisssors 오브젝트에 wrong sound clip 추가 필요
        if (TrashObject == null || TrashObject.bChanged)
        {
            PlayAudioClip(wrongClip);
        }

        yAngle += Time.deltaTime * rotationSpeed;
        if(yAngle > rotationAngle*2)
        {
            yAngle -= rotationAngle*2;
        }

        leftPart.transform.rotation = Quaternion.Euler(0f, Mathf.Min(yAngle, rotationAngle*2-yAngle), 0f);
        rightPart.transform.rotation = Quaternion.Euler(0f, -Mathf.Min(yAngle, rotationAngle*2-yAngle), 0f);
    }

    void PlayAudioClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.PlayOneShot(clip);
    }
}
