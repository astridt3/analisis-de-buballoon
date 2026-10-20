using System;
using TMPro;
using Unity.Services.Analytics;
using UnityEngine;

public class CarrotLogic : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CarrotText;
    [SerializeField] private int carrotID;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("Carrot_" + carrotID, 1);
            PlayerPrefs.Save();
            int total = GetTotalCarrots();
            CarrotText.text = total.ToString();
            try
            {
                AnalyticsManager.instance.ColectCarrot(carrotID);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            Destroy(gameObject);
        }
    }

    private int GetTotalCarrots()
    {
        int total = 0;
        for (int i = 1; i <= 3; i++)
        {
            total += PlayerPrefs.GetInt("Carrot_" + i, 0);
        }
        return total;

    }
}
