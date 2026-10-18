using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Analytics;
using Unity.Services.Core;
using System;
using UnityEngine.SceneManagement;

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

    //public void ButtonPressed(string action, string screen_id)
    //{
    //    ButtonPressedEvent evt = new ButtonPressedEvent
    //    {
    //        actionName = action,
    //        screen_id = screen_id
    //    };

    //    AnalyticsService.Instance.RecordEvent(evt);
    //    AnalyticsService.Instance.Flush();
    //}

    //public void PlayerDied(int playerScore, int jumps, int obstaclesHit, string deathReason, int milestone)
    //{
    //    PlayerDiedEvent evt = new PlayerDiedEvent
    //    {
    //        player_score = playerScore,
    //        jumps = jumps,
    //        obstaclesHit = obstaclesHit,
    //        deathReason = deathReason,
    //        milestone = milestone
    //    };

    //    AnalyticsService.Instance.RecordEvent(evt);
    //    AnalyticsService.Instance.Flush();
    //}

    //public void ReachedMilestone(int milestone, int jumps, int obstaclesHit)
    //{
    //    ReachedMilestoneEvent evt = new ReachedMilestoneEvent
    //    {
    //        milestone_score = milestone,
    //        jumps = jumps,
    //        obstaclesHit = obstaclesHit
    //    };
    //    AnalyticsService.Instance.RecordEvent(evt);
    //    AnalyticsService.Instance.Flush();
    //}
    public void ColectCarrot(int carrotID)
    {
        ColectCarrotEvent evt = new ColectCarrotEvent
        {
            Carrot_score = carrotID,
          
        };
        AnalyticsService.Instance.RecordEvent(evt);
        AnalyticsService.Instance.Flush();
    }

}