using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] trashPrefabs;                     // 생성할 쓰레기의 프리팹
    public float spawnInterval = 2f;                      // 생성 간격
    public Vector3 genPos = new Vector3(0f, 1f, 0f);      // 초기 생성위치
    private int totalScore;

    private float timer;

    void Start()
    {
        totalScore = 0;
        timer = 0f;
    }

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
        GameObject randomTrashPrefab = trashPrefabs[Random.Range(0, trashPrefabs.Length)];
        GameObject trash = Instantiate(randomTrashPrefab, genPos, Quaternion.identity);
        trash.transform.SetParent(transform);
    }

    public void getScore(int score)
    {
        totalScore += score;

        Debug.Log("Total Score: " + totalScore);
    }
}
