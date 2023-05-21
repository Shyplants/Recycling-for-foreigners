using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Color newColor;

    void Start()
    {
        Renderer cubeRenderer = GetComponent<Renderer>();
        cubeRenderer.material.color = newColor;
    }
}
