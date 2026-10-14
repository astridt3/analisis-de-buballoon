
using UnityEngine;


public class Trampolin : MonoBehaviour
{
    public GameObject Player;
    public Animator animator;
    [Header("impulso del salto modificable")]
    [SerializeField] private float bounce = 20f;
    private CharacterBehaviour characterBehaviour;
    [SerializeField] private AudioClip bounce1;
    [SerializeField] private AudioClip bounce2;

    private void Start()
    {
        characterBehaviour = Player.GetComponent<CharacterBehaviour>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            characterBehaviour.isGrounded = false;
            animator.Play("Trampolin Animacion");
            PlayRandomSound();
        }
     
    }
    
    private void PlayRandomSound()
    {
        SoundManager.audioSource.volume = 0.5f;
        AudioClip selectedClip = (Random.Range(0, 2) == 0) ? bounce1 : bounce2;
        SoundManager.instance.PlaySound(selectedClip);
    }
}