using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public List<Image> heartImages;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    /// <param name="currentHealth">
    public void UpdateHeartUI(int currentHealth)
    {
        for (int i = 0; i < heartImages.Count; i++)
        {
            if (i < currentHealth)
            {
                heartImages[i].sprite = fullHeart;
            }
            else
            {
                heartImages[i].sprite = emptyHeart;

                // analytic event register
                try
                {
                    AnalyticsManager.instance.emptyHeartCount();
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }
        }
    }
}