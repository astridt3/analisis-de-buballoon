using System;
using UnityEngine;

public class CoinLogic : MonoBehaviour
{
    [SerializeField] private int bowId;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MedalManager.instance.AddCoin();
            // analytic event register
            try
            {
                CharacterBehaviour character = collision.GetComponent<CharacterBehaviour>();
                AnalyticsManager.instance.RegisterBowCollected(bowId, character.GetCurrentSectionId(), character.transform.position);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            Destroy(gameObject);
        }
    }
}
