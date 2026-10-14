using UnityEngine;

public class CoinLogic : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MedalManager.instance.AddCoin();
            Destroy(gameObject);
        }
    }
}
