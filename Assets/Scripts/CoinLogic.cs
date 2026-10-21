using System;
using UnityEngine;

public class CoinLogic : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MedalManager.instance.AddCoin();
            // analytic event register
            try
            {
                AnalyticsManager.instance.coinCount();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            Destroy(gameObject);
        }
    }
}
