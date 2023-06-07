using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] trashPrefabs;                     // 생성할 쓰레기의 프리팹
    public TMP_Text textField;
    public Texture[] trashMarks;
    public RawImage trashImage;
    public float spawnInterval = 2f;                      // 생성 간격
    public float limitTime = 200f;                      
    public float runningTime = 0f;
    public Vector3 genPos = new Vector3(0f, 1f, 0f);      // 초기 생성위치
    private int totalScore, remainingSeconds;

    private float genTimer;

    void Start()
    {
        totalScore = 0;
        genTimer = 0f;
    }

    void Update()
    {
        runningTime += Time.deltaTime;
        genTimer += Time.deltaTime;

        if(runningTime >= limitTime)
        {
            Application.Quit();
        }

        if(genTimer >= spawnInterval)
        {
            GenerateTrash();
            genTimer = 0f;
        }

        Draw();
    }

    void Draw()
    {
        textField.text = "Total Score: " + totalScore + "\n";
        
        remainingSeconds = Mathf.FloorToInt(limitTime - runningTime);
        textField.text += "Remaining Time: " + string.Format("{0:D2}:{1:D2}", remainingSeconds/60, remainingSeconds%60);
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

    int TrashType2ID(TrashType trashType)
    {
        int id = -1;
        switch(trashType)
        {
            case TrashType.General:
                break;
            case TrashType.Paper:
                id = 0;
                break;
            case TrashType.PaperPack:
                id = 1;
                break;
            case TrashType.MetalCan:
                id = 2;
                break;
            case TrashType.GlassBottle:
                break;
            case TrashType.PlasticBottle:
                id = 4;
                break; 
            case TrashType.PlasticContainer:
                id = 5;
                break;
            case TrashType.VinylProuduct:
                id = 6;
                break;
        }

        return id;
    }

    public void clearTrashImage()
    {
        trashImage.texture = null;
    }
    public void setTrashImage(TrashType trashType)
    {
        int id = TrashType2ID(trashType);
        if(id == -1)
        {
            clearTrashImage();
        }
        else
        {
            trashImage.texture = trashMarks[id];
        }
    }
}
