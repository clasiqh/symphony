using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {

    public AudioClip SoundToPlay;

    [Range(0f,1f)]
    public float Volume;

    AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();

    }

    void OnTriggerEnter()
    {
            audio.PlayOneShot(SoundToPlay, Volume);
    }
}
