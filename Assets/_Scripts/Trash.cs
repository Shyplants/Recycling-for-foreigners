using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TrashType
{
    General,                    // 일반 쓰레기
    Paper,                      // 종이류
    PaperPack,                  // 종이팩
    MetalCan,                   // 금속캔
    GlassBottle,                // 유리병
    PlasticBottle,              // 페트병
    PlasticContainer,           // 플라스틱 용기
    VinylProuduct               // 비닐류
}

public class Trash : MonoBehaviour
{
    public TrashType trashType;
    public Mesh newMesh;

    public void ChangeMesh()
    {
        if(newMesh == null) return;

        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if(meshFilter != null)
        {
            meshFilter.sharedMesh = newMesh;
        }
    }
}
