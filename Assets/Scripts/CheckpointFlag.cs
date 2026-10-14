using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointFlag : MonoBehaviour
{
    [SerializeField] private List<Sprite> popFrames;
    [SerializeField] private List<Sprite> luegoFrames;
    [SerializeField] private float frameRate = 0.1f;

    private SpriteRenderer spriteRenderer;
    private bool animating = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !animating)
        {
            StartCoroutine(PlayFlagAnimation());
        }
    }

    private IEnumerator PlayFlagAnimation()
    {
        animating = true;
        for (int i = 0; i < popFrames.Count; i++)
        {
            spriteRenderer.sprite = popFrames[i];
            yield return new WaitForSeconds(frameRate);
        }
        StartCoroutine(LoopLuego());
    }

    private IEnumerator LoopLuego()
    {
        while (true)
        {
            for (int i = 0; i < luegoFrames.Count; i++)
            {
                spriteRenderer.sprite = luegoFrames[i];
                yield return new WaitForSeconds(frameRate);
            }
        }
    }
}
