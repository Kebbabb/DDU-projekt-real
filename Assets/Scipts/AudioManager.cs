using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    public List<AudioClip> sources = new List<AudioClip>();

    public AudioSource audioSource;

    private void Awake()
    {

        if (instance != null && instance != this)
        {
            
        }
        else
        {
            instance = this;
            
        }
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
       
    }

    public void UseSoundEffect(int clip)
    {
        audioSource.clip = sources[clip];
        audioSource.Play();
    }
}
