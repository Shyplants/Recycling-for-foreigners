using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class BackgroundSound : MonoBehaviour
{
    [Tooltip("백그라운드 사운드 이펙트 저장 변수")]
    public AudioClip backgroundSoundEffect;
    public AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        if (backgroundSoundEffect == null)
            backgroundSoundEffect = Resources.Load<AudioClip>("Audio/Background");

        audioSource.clip = backgroundSoundEffect;   
        audioSource.loop = true;

        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
