using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSoundEffect : MonoBehaviour
{
    [Tooltip("객체 충돌시 사운드 이펙트 저장 변수")]
    public AudioClip soundEffect;
    private AudioSource audioSource;

    [Tooltip("게임 오브젝트의 tag값 저장 변수")]
    private string myTag;

    [Tooltip("물리 효과 위한 RigidBody")]
    private Rigidbody myRigidbody;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        myRigidbody = GetComponent<Rigidbody>();

        if(myRigidbody == null)
            myRigidbody = gameObject.AddComponent<Rigidbody>();

        myTag = gameObject.tag;

        switch(myTag) 
        {
            case "Metal":
                soundEffect = Resources.Load<AudioClip>("Audio/Metal");
                break;
            case "Paper":
                soundEffect = Resources.Load<AudioClip>("Audio/Paper");
                break;
            case "Glass":
                soundEffect = Resources.Load<AudioClip>("Audio/Glass");
                break;
            case "Plastic":
                soundEffect = Resources.Load<AudioClip>("Audio/Plastic");
                break;
        }

        Debug.Log(soundEffect.name);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Entered");

        audioSource.PlayOneShot(soundEffect);
    }

}
