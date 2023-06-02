using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBinTrigger : MonoBehaviour
{
    public AudioClip correctClip;
    public AudioClip wrongClip;
    private AudioSource audioSource;
    private TrashBin parentObject;
    private TrashType trashType;

    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        parentObject = transform.parent.GetComponent<TrashBin>();

        if(parentObject != null)
        {
            trashType = parentObject.trashType;
        }
    }
    void OnTriggerEnter(Collider other) {
        Debug.Log("TriggerEnter");
        Trash trash = other.GetComponent<Trash>();

        if(trash != null)
        {
            if(trashType == trash.trashType)
            {
                PlayAudioClip(correctClip);
                Debug.Log("Correct");
            }
            else
            {
                PlayAudioClip(wrongClip);
                Debug.Log("Wrong");
            }
        }

        Destroy(other.gameObject);
    }

    void PlayAudioClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.PlayOneShot(clip);
    }
}