using System;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;

public class AnalyticsManager : MonoBehaviour
{
    public static AnalyticsManager instance;

    public void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    async void Start()
    {
        try
        {
            await UnityServices.InitializeAsync();
            GiveConsent();
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

    public void GiveConsent()
    {
        AnalyticsService.Instance.StartDataCollection();
        Debug.Log($"Consent given! We can get the data!!!");
    }

    public void PlayerDied()
    {
        PlayerDiedEvent evt = new PlayerDiedEvent { };

        AnalyticsService.Instance.RecordEvent(evt);
    }

    public void ColectCarrot(int carrotID)
    {
        ColectCarrotEvent evt = new ColectCarrotEvent
        {
            Carrot_score = carrotID
        };

        AnalyticsService.Instance.RecordEvent(evt);
        AnalyticsService.Instance.Flush();
    }
    public void PlayerVictory()
    {
        PlayerVictoryEvent evt = new PlayerVictoryEvent { };

        AnalyticsService.Instance.RecordEvent(evt);
    }
    public void bubbleMode()
    {
        BubbleModeEvent evt = new BubbleModeEvent { };

        AnalyticsService.Instance.RecordEvent(evt);
    }
    public void grappler() //script puesto como gancho
    {
        grapplerEvent evt = new grapplerEvent { };

        AnalyticsService.Instance.RecordEvent(evt);
    }
    public void coinCount()
    {
        coinEvent evt = new coinEvent { };

        AnalyticsService.Instance.RecordEvent(evt);
    }
    public void emptyHeartCount()
    {
        emptyHeartCountEvent evt = new emptyHeartCountEvent { };

        AnalyticsService.Instance.RecordEvent(evt);
    }
}