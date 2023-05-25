using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawSphere : MonoBehaviour
{
    public Vector3 center;
    public float radius = 2f;
    GameObject sphere;

    void Start()
    {
        center = transform.position;
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(radius * 2f, radius * 2f, radius * 2f);
    }

    void Update()
    {
        center = transform.position;
        sphere.transform.position = center;
    }
}
