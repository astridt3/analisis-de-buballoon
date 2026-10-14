
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public static AudioSource audioSource;
    public AudioClip[] bounceSounds;

    private void Awake()
    {
   
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        } 
        
    }

    public void PlaySound(AudioClip sound)
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(sound);
    }

    //public void PlaySoundRepeating(AudioClip sound)
    //{
       
    //}
    public void PlayRandomTrampolineSound()
    {
        if (bounceSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, bounceSounds.Length); 
            PlaySound(bounceSounds[randomIndex]); 
        }
    }
}
