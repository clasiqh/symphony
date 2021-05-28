using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{



    [SerializeField] private AudioClip defaultSound;
    private static AudioClip defaultSoundStatic;
    private static AudioSource audioSource;
    [SerializeField] private AudioClip drawerOpen;
    private static AudioClip drawerOpenStatic;
    [SerializeField] private AudioClip drawerClose;
    private static AudioClip drawerCloseStatic;
    [SerializeField] private AudioClip click;
    private static AudioClip clickStatic;


    void Awake()
    {
        audioSource = this.GetComponent<AudioSource>();
        defaultSoundStatic = defaultSound;
        drawerOpenStatic = drawerOpen;
        drawerCloseStatic = drawerClose;
        clickStatic = click;
    }


    public static void playDefaultSound()
    {

        if (CastRay.detected.tag == "lookable")
        { 
            audioSource.pitch = (Random.Range(0.88f, 1.2f));
            audioSource.PlayOneShot(defaultSoundStatic, 0.5f);
        }


    }

    public static void DrawerOpenSFX()
    {
        audioSource.pitch = (Random.Range(0.6f, 1.4f));
        audioSource.PlayOneShot(drawerOpenStatic, 0.8f);
    }
    public static void DrawerCloseSFX()
    {
        audioSource.pitch = (Random.Range(0.6f, 1.4f));
        audioSource.PlayOneShot(drawerCloseStatic, 0.8f);
    }

    public static void clickSFX()
    {
        audioSource.pitch = (Random.Range(0.88f, 1.4f));
        audioSource.PlayOneShot(clickStatic, 0.8f);
    }



}
