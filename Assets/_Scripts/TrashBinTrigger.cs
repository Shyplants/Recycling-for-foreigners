using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBinTrigger : MonoBehaviour
{
    public AudioClip correctClip;
    public AudioClip wrongClip;
    private GameManager gameManager;
    private AudioSource audioSource;
    private TrashBin parentObject;
    private TrashType trashType;
    private bool bInit = false;
    private int score;

    
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        audioSource = GetComponent<AudioSource>();
        parentObject = transform.parent.GetComponent<TrashBin>();

        if(parentObject != null)
        {
            trashType = parentObject.trashType;
        }
    }

    public void Init(int _score)
    {
        bInit = true;
        score = _score;
    }

    void OnTriggerEnter(Collider other) {
        if(!bInit) return;

        Trash trash = other.GetComponent<Trash>();

        if(trash != null)
        {
            if(trashType == trash.trashType)
            {
                PlayAudioClip(correctClip);
                Debug.Log("Correct");

                if(gameManager != null)
                {
                    gameManager.getScore(score);
                }
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