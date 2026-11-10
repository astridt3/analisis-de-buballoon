using System;
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

    // MUERTES

    public void PlayerDied()
    {
        AnalyticsService.Instance.RecordEvent(new DeathCoordinatesEvent());
    }

    public void RegisterPlayerDeath(Vector3 deathPosition)
    {
        // Registra que el jugador murió.
        AnalyticsService.Instance.RecordEvent(new PlayerDiedEvent());

        // Registra dónde ocurrió la muerte.
        DeathCoordinatesEvent evt = new DeathCoordinatesEvent
        {
            X = deathPosition.x,
            Y = deathPosition.y
        };

        AnalyticsService.Instance.RecordEvent(evt);
    }

    public void RegisterLifeLost()
    {
        AnalyticsService.Instance.RecordEvent(new LostLifeEvent());
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
        ColectCarrot(carrotID);
    }

    // MOÑOS

    public void coinCount()
    {
        AnalyticsService.Instance.RecordEvent(new coinEvent());
    }

    public void RegisterBowCollected()
    {
        bowsCollected++;
        coinCount();
    }

    // GANCHO

    public void RegisterHookUsed()
    {
        hookUsed = true;

        AnalyticsService.Instance.RecordEvent(new grapplerEvent());
    }

    // GLOBOS

    public void RegisterBubbleUsed()
    {
        bubbleUsed = true;

        AnalyticsService.Instance.RecordEvent(new BubbleModeEvent());
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

        hookUsed = false;
        bubbleUsed = false;
    }

    // TIEMPOS

    public void BeginLevelAttempt()
    {
        attemptStartTime = Time.time;
        sectorStartTime = Time.time;

        attemptTimerStarted = true;

        sector1Recorded = false;
        sector2Recorded = false;
        sector3Recorded = false;
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

    // CHECKPOINT SKIP

    public void RegisterCheckpointSkipped(int checkpointId)
    {
        CheckpointSkippedEvent evt = new CheckpointSkippedEvent
        {
            CheckpointId = checkpointId
        };

        AnalyticsService.Instance.RecordEvent(evt);
    }

    // BURBUJAS VERDES

    public void RegisterGreenBubble(int bubbleId)
    {
        GreenBubbleEvent evt = new GreenBubbleEvent
        {
            BubbleId = bubbleId
        };

        AnalyticsService.Instance.RecordEvent(evt);
    }
}