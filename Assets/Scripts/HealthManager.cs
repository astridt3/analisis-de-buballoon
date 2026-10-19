
using System;
using Unity.VisualScripting;
using UnityEngine;
public class HealthManager : MonoBehaviour
{
    private float maxHealth = 3;
    public float currentHealth;
    public GameController gameController;
    public HeartManager heartManager;
    public GameObject derrota;
    public int respawnCount = 0;
    [SerializeField] private AudioClip hurt1;
    [SerializeField] private AudioClip hurt2;
    private CharacterBehaviour character;
    void Start()
    {
        currentHealth = maxHealth;
        if (heartManager == null)
        {
            heartManager = FindObjectOfType<HeartManager>();
        }
        heartManager.UpdateHeartUI((int)currentHealth);
        character = GetComponent<CharacterBehaviour>();
    }

    public void TakeDamage(float amount, bool fromLava)
    {
        currentHealth -= amount;
        Debug.Log($"Vida actual: {currentHealth}");
        AudioClip selectedClip = (Random.Range(0, 2) == 0) ? hurt1 : hurt2;
        SoundManager.instance.PlaySound(selectedClip);
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        heartManager.UpdateHeartUI((int)currentHealth);

        if (currentHealth <= 0)
        {
            Die();
            return;
        }
        if (fromLava)
        {
            if (currentHealth >= 1)
            {
                character.RespawnAtLastGround();
            }
            else
            {
                character.RespawnAtCheckpoint();
            }
        }
        
    }


    public void Die()
    {
        // analytic event register
        try
        {
            AnalyticsManager.instance.PlayerDied();
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }

        if (respawnCount >= 2)
        {
            Time.timeScale = 0;
            derrota.SetActive(true);
            Debug.Log("Jugador ha muerto definitivamente");
            return;
        }
        respawnCount++;
        currentHealth = maxHealth - respawnCount;
        heartManager.UpdateHeartUI((int)currentHealth);
        character.RespawnAtCheckpoint();
        //currentHealth = maxHealth;
        //heartManager.UpdateHeartUI((int)currentHealth);
        //character.RespawnAtCheckpoint();
    }
}