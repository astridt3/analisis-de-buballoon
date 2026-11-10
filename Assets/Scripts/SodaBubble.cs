using UnityEngine;

public class SodaBubble : MonoBehaviour
{
    public Animator anima;
    private bool isExploding = false; 
    [SerializeField] private float destroyTimer = 10f; 
    private float elapsedTime = 0f;
    [SerializeField] private AudioClip pop1;
    [SerializeField] private AudioClip pop2;

    private static int nextBubbleId = 0;
    private int bubbleId;

    private void Awake()
    {
        anima = GetComponent<Animator>();

        bubbleId = nextBubbleId++;
    }

    private void Update()
    {
        if (!isExploding)
        {
            elapsedTime += Time.deltaTime;
            
            if (elapsedTime >= destroyTimer)
            {
                TriggerExplosion();
            } 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isExploding)
        {
            AnalyticsManager.instance.RegisterGreenBubble(bubbleId);

            TriggerExplosion();

            AudioClip selectedClip = (Random.Range(0, 2) == 0) ? pop1 : pop2;
            SoundManager.instance.PlaySound(selectedClip);
        }
    }

    private void TriggerExplosion()
    {
        isExploding = true;
        anima.Play("Burbuja_Explotar");
        Destroy(gameObject, 0.6f);
    }
}
