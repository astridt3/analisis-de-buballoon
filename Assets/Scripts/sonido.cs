
using UnityEngine;

public class sonido : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource music;
    public AudioClip Clickaudio;
    public AudioClip Quit;

    void Start()
    {
        music = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    public void ClickAudioOn()

    {
        music.PlayOneShot(Clickaudio);
    }
    public void QuitSound()

    {
        music.PlayOneShot(Quit);
    }

}
