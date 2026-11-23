using System;
using System.Collections.Generic;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;

public class AnalyticsManager : MonoBehaviour
{
    public static AnalyticsManager instance;

    // Datos de la partida actual
    private int carrotsCollected;
    private int bowsCollected;

    private bool hookUsed;
    private bool bubbleUsed;

    private float attemptStartTime;
    private float sectorStartTime;
    private bool attemptTimerStarted;

    private bool sector1Recorded;
    private bool sector2Recorded;
    private bool sector3Recorded;

    // RUN TRACKING
    private string currentRunId;
    private const string levelId = "level_1";

    private float runStartTime;
    private bool runEnded;

    private int lastCheckpointId;
    private Vector2 lastPlayerPosition;

    private int deathCount;

    private HashSet<string> reachedSections = new HashSet<string>();

    private bool balloonUsedThisRun;

    private string currentSessionId;

    private string lastAction = "none";

    public void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);

        currentSessionId = Guid.NewGuid().ToString();
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

    // MUERTES

    public void PlayerDied()
    {
        AnalyticsService.Instance.RecordEvent(new DeathCoordinatesEvent());
    }

    public void RegisterPlayerDeath(string causeId, string sectionId, Vector3 deathPosition, int livesRemaining)
    {
        deathCount++;

        PlayerDiedEvent evt = new PlayerDiedEvent
        {
            DeathId = deathCount,
            CauseId = causeId,
            SectionId = sectionId,
            PositionX = deathPosition.x,
            PositionY = deathPosition.y,
            LivesRemaining = livesRemaining
        };

        AnalyticsService.Instance.RecordEvent(evt);
    }

    public void RegisterLifeLost(string sourceId, string sectionId, Vector3 position, int livesRemaining)
    {
        LifeLostEvent evt = new LifeLostEvent
        {
            SourceId = sourceId,
            SectionId = sectionId,
            PositionX = position.x,
            PositionY = position.y,
            LivesRemaining = livesRemaining
        };

        AnalyticsService.Instance.RecordEvent(evt);
    }

    // ZANAHORIAS

    public void ColectCarrot(int carrotID)
    {
        ColectCarrotEvent evt = new ColectCarrotEvent
        {
            Carrot_score = carrotID
        };

        AnalyticsService.Instance.RecordEvent(evt);
    }

    public void RegisterCarrotCollected(int carrotID)
    {
        carrotsCollected++;

        CarrotCollectedEvent evt = new CarrotCollectedEvent
        {
            CollectibleId = carrotID,
            CarrotsCount = carrotsCollected,
            CarrotsTotal = 3
        };

        AnalyticsService.Instance.RecordEvent(evt);
    }

    private void RegisterCarrotCollectionSummary()
    {
        CarrotCollectionSummaryEvent evt = new CarrotCollectionSummaryEvent
        {
            CarrotsCount = carrotsCollected,
            CarrotsTotal = 3,
            AllThreeCollected = carrotsCollected == 3
        };

        AnalyticsService.Instance.RecordEvent(evt);
    }

    // MOÑOS

    public void BowCollected()
    {
        AnalyticsService.Instance.RecordEvent(new BowCollectedEvent());
    }

    public void RegisterBowCollected(int bowId, string sectionId, Vector3 position)
    {
        bowsCollected++;

        BowCollectedEvent evt = new BowCollectedEvent
        {
            BowId = bowId,
            SectionId = sectionId,
            PositionX = position.x,
            PositionY = position.y
        };

        AnalyticsService.Instance.RecordEvent(evt);
    }

    // GANCHO

    public void RegisterHookActivated(int hookId, string sectionId, string activationResult, bool used)
    {
        HookActivatedEvent evt = new HookActivatedEvent
        {
            HookId = hookId,
            SectionId = sectionId,
            ActivationResult = activationResult,
            Used = used
        };

        AnalyticsService.Instance.RecordEvent(evt);
    }

    private void RegisterHookOpportunities()
    {
        HookPoint[] hookPoints = FindObjectsOfType<HookPoint>();

        foreach (HookPoint hookPoint in hookPoints)
        {
            if (!reachedSections.Contains(hookPoint.SectionId))
                continue;

            HookOpportunityResolvedEvent evt = new HookOpportunityResolvedEvent
            {
                HookId = hookPoint.HookId,
                SectionId = hookPoint.SectionId,
                Used = hookPoint.Used
            };

            AnalyticsService.Instance.RecordEvent(evt);
        }
    }

    // GLOBOS

    public void RegisterBubbleUsed()
    {
        bubbleUsed = true;

        AnalyticsService.Instance.RecordEvent(new BubbleModeEvent());
    }

    public void RegisterBalloonActivated(string sectionId, Vector3 position)
    {
        if (balloonUsedThisRun)
            return;

        balloonUsedThisRun = true;

        BalloonActivatedEvent evt = new BalloonActivatedEvent
        {
            OpportunityId = 1,
            SectionId = sectionId,
            Used = true,
            PositionX = position.x,
            PositionY = position.y
        };

        AnalyticsService.Instance.RecordEvent(evt);
    }

    private void RegisterBalloonOpportunityResolved(string sectionId, Vector3 position)
    {
        BalloonOpportunityResolvedEvent evt = new BalloonOpportunityResolvedEvent
        {
            OpportunityId = 1,
            SectionId = sectionId,
            Used = balloonUsedThisRun,
            PositionX = position.x,
            PositionY = position.y
        };

        AnalyticsService.Instance.RecordEvent(evt);
    }

    // FINALIZACIÓN DEL NIVEL

    public void RegisterLevelCollectibles()
    {
        AnalyticsService.Instance.RecordEvent(new LevelFinishedEvent());

        if (carrotsCollected == 0)
        {
            AnalyticsService.Instance.RecordEvent(new NoObtainedCollectiblesEvent());
        }

        if (carrotsCollected == 3)
        {
            AnalyticsService.Instance.RecordEvent(new Obtained3CollectiblesEvent());
        }

        if (!hookUsed)
        {
            AnalyticsService.Instance.RecordEvent(new HookNotUsedEvent());
        }

        if (!bubbleUsed)
        {
            AnalyticsService.Instance.RecordEvent(new BalloonNotUsedEvent());
        }
    }

    // REINICIO DE PARTIDA

    public void ResetAttemptData()
    {
        carrotsCollected = 0;
        bowsCollected = 0;

        lastAction = "none";

        hookUsed = false;
        bubbleUsed = false;
        balloonUsedThisRun = false;
    }

    // TIEMPOS

    public void BeginLevelAttempt()
    {
        currentRunId = Guid.NewGuid().ToString();

        runStartTime = Time.realtimeSinceStartup;
        runEnded = false;
        lastAction = "none";

        deathCount = 0;
        balloonUsedThisRun = false;
        carrotsCollected = 0;

        lastCheckpointId = 0;
        lastPlayerPosition = Vector2.zero;

        // Mantener el sistema de tiempo por sectores existente.
        attemptStartTime = Time.time;
        sectorStartTime = Time.time;
        attemptTimerStarted = true;

        sector1Recorded = false;
        sector2Recorded = false;
        sector3Recorded = false;

        reachedSections.Clear();
        reachedSections.Add("start_to_cp1");

        HookPoint[] hookPoints = FindObjectsOfType<HookPoint>();

        foreach (HookPoint hookPoint in hookPoints)
        {
            hookPoint.ResetUsage();
        }

        LevelRunStartedEvent evt = new LevelRunStartedEvent
        {
            RunId = currentRunId
        };

        AnalyticsService.Instance.RecordEvent(evt);
    }

    public void RegisterCheckpointReached(int checkpointId, string sectionId)
    {
        if (!attemptTimerStarted)
            return;

        float elapsedSeconds = Time.time - sectorStartTime;

        CheckpointReachedEvent evt = new CheckpointReachedEvent
        {
            CheckpointId = checkpointId,
            SectionId = sectionId,
            ElapsedSeconds = elapsedSeconds
        };

        AnalyticsService.Instance.RecordEvent(evt);
    }

    public void RegisterSectorCompleted(int sectorId)
    {
        if (!attemptTimerStarted)
            return;

        switch (sectorId)
        {
            case 1:
                if (sector1Recorded) return;
                sector1Recorded = true;
                break;

            case 2:
                if (sector2Recorded) return;
                sector2Recorded = true;
                break;

            case 3:
                if (sector3Recorded) return;
                sector3Recorded = true;
                break;

            default:
                return;
        }

        float elapsedTime = Time.time - sectorStartTime;

        AverageTimeEvent evt = new AverageTimeEvent
        {
            SectorId = sectorId,
            TimeSeconds = elapsedTime
        };

        AnalyticsService.Instance.RecordEvent(evt);

        sectorStartTime = Time.time;
    }

    public void RegisterPlayersMaxTime(Vector3 playerPosition)
    {
        if (!attemptTimerStarted)
            return;

        float elapsedTime = Time.time - attemptStartTime;

        PlayersMaxTimeEvent evt = new PlayersMaxTimeEvent
        {
            TimeSeconds = elapsedTime,
            X = playerPosition.x,
            Y = playerPosition.y
        };

        AnalyticsService.Instance.RecordEvent(evt);
    }

    public void RegisterLevelSelectTime(float timeSeconds)
    {
        LevelSelectTimeEvent evt = new LevelSelectTimeEvent
        {
            TimeSeconds = timeSeconds
        };

        AnalyticsService.Instance.RecordEvent(evt);
    }

    public void RegisterLevelSelectionCompleted(string selectedLevelId, float durationSeconds)
    {
        LevelSelectionCompletedEvent evt = new LevelSelectionCompletedEvent
        {
            SelectedLevelId = selectedLevelId,
            DurationSeconds = durationSeconds,
            SessionId = currentSessionId
        };

        AnalyticsService.Instance.RecordEvent(evt);
    }

    // CHECKPOINT SKIP

    public void RegisterCheckpointSkipped(int checkpointId, int nextCheckpointId, Vector3 playerPosition)
    {
        CheckpointSkippedEvent evt = new CheckpointSkippedEvent
        {
            CheckpointId = checkpointId,
            NextCheckpointId = nextCheckpointId,
            PositionX = playerPosition.x,
            PositionY = playerPosition.y
        };

        AnalyticsService.Instance.RecordEvent(evt);
    }

    // BURBUJAS VERDES

    public void RegisterGreenBubble(int bubbleId, string sectionId, bool lifeLost, Vector3 position)
    {
        GreenBubbleTouchedEvent evt = new GreenBubbleTouchedEvent
        {
            BubbleId = bubbleId,
            SectionId = sectionId,
            LifeLost = lifeLost,
            PositionX = position.x,
            PositionY = position.y
        };

        AnalyticsService.Instance.RecordEvent(evt);
    }

    // nuevo
    public void RegisterLastCheckpoint(int checkpointId)
    {
        lastCheckpointId = checkpointId;
    }

    public void EndLevelAttempt(string endReason, Vector3 playerPosition, string sectionId, int livesRemaining)
    {
        if (!attemptTimerStarted || runEnded)
            return;

        runEnded = true;
        attemptTimerStarted = false;

        float duration = Time.realtimeSinceStartup - runStartTime;

        RegisterHookOpportunities();
        RegisterBalloonOpportunityResolved(sectionId, playerPosition);
        RegisterCarrotCollectionSummary();

        string finalAction = lastAction;

        if (endReason == "completed")
        {
            finalAction = "completed";
        }
        else if (endReason == "defeated")
        {
            finalAction = "defeated";
        }
        else if (finalAction == "none")
        {
            finalAction = "exit_button";
        }

        LevelRunEndedEvent evt = new LevelRunEndedEvent
        {
            RunId = currentRunId,
            LevelId = levelId,
            DurationSeconds = duration,
            EndReason = endReason,
            LastPositionX = playerPosition.x,
            LastPositionY = playerPosition.y,
            LastCheckpointId = lastCheckpointId,
            LastAction = finalAction,
            LivesRemaining = Mathf.Max(0, livesRemaining)
        };

        AnalyticsService.Instance.RecordEvent(evt);

        Debug.Log($"Partida finalizada: {endReason} | {duration:F2} segundos");
    }

    public void RegisterSectionReached(string sectionId)
    {
        reachedSections.Add(sectionId);
    }

    public void RegisterLastAction(string action)
    {
        if (!attemptTimerStarted || string.IsNullOrEmpty(action))
            return;

        lastAction = action;
    }
}