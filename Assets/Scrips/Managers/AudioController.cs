using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource audioManager;
    [SerializeField] List<AudioClip> clips;

    public void PlayMusic()
    {
        audioManager.clip = clips[Random.Range(0, clips.Count)];
        audioManager.Play();
    }
}
