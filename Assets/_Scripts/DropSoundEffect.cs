using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSoundEffect : MonoBehaviour
{
    public AudioClip[] collisionSound = new AudioClip[4];
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        string collidedObjectTag = collision.gameObject.tag;

        switch(collidedObjectTag) 
        {
            case "Metal":
                audioSource.PlayOneShot(collisionSound[0]);
                break;
            case "Paper":
                audioSource.PlayOneShot(collisionSound[1]);
                break;
            case "Glass":
                audioSource.PlayOneShot(collisionSound[2]);
                break;
            case "Plastic":
                audioSource.PlayOneShot(collisionSound[3]);
                break;
        }
    }
}
