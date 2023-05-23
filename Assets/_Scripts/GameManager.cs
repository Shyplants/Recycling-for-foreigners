using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject trashPrefab;                        // 생성할 쓰레기의 프리팹
    public float spawnInterval = 2f;                      // 생성 간격
    public Vector3 genPos = new Vector3(0f, 1f, 0f);      // 초기 생성위치

    private float timer = 0f;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= spawnInterval)
        {
            GenerateTrash();
            timer = 0f;
        }
    }

    void GenerateTrash()
    {
        GameObject trash = Instantiate(trashPrefab, genPos, Quaternion.identity);
        trash.transform.SetParent(transform);
    }
}
