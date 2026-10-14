
using UnityEngine;

public class PlataformasNube : MonoBehaviour
{
    private float tiempoDesaparece = 2f;
    private float tiempoReaparece = 3f;
    [SerializeField] private AudioClip vanish1;
    private Collider2D colisionador;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        colisionador = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke(nameof(Desaparecer), tiempoDesaparece);
            
        }
    }

    private void Desaparecer()
    {
        SoundManager.instance.PlaySound(vanish1);
        colisionador.enabled = false;
        spriteRenderer.enabled = false;

        Invoke(nameof(Reaparecer), tiempoReaparece);
    }
    private void Reaparecer()
    {
        colisionador.enabled = true;
        spriteRenderer.enabled = true;
    }
}
