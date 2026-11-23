using Unity.Services.Analytics;

// analytic custom events classes for overrides

public class PlayerDiedEvent : Event
{
    public PlayerDiedEvent() : base("PlayerDied") { }

    public int DeathId
    {
        set { SetParameter("death_id", value); }
    }

    public string CauseId
    {
        set { SetParameter("cause_id", value); }
    }

    public string SectionId
    {
        set { SetParameter("section_id", value); }
    }

    public float PositionX
    {
        set { SetParameter("position_x", value); }
    }

    public float PositionY
    {
        set { SetParameter("position_y", value); }
    }

    public int LivesRemaining
    {
        set { SetParameter("lives_remaining", value); }
    }
}

public class LifeLostEvent : Event
{
    public LifeLostEvent() : base("LifeLost") { }

    public string SourceId
    {
        set { SetParameter("source_id", value); }
    }

    public string SectionId
    {
        set { SetParameter("section_id", value); }
    }

    public float PositionX
    {
        set { SetParameter("position_x", value); }
    }

    public float PositionY
    {
        set { SetParameter("position_y", value); }
    }

    public int LivesRemaining
    {
        set { SetParameter("lives_remaining", value); }
    }
}

public class DeathCoordinatesEvent : Event
{
    public DeathCoordinatesEvent() : base("death_coordinates") { }

    public float X
    {
        set { SetParameter("x_coord", value); }
    }

    public float Y
    {
        set { SetParameter("y_coord", value); }
    }
}

public class LevelFinishedEvent : Event
{
    public LevelFinishedEvent() : base("level_finished") { }
}

public class Obtained3CollectiblesEvent : Event
{
    public Obtained3CollectiblesEvent() : base("obtained_3_collectibles") { }
}

public class NoObtainedCollectiblesEvent : Event
{
    public NoObtainedCollectiblesEvent() : base("no_obtained_collectibles") { }
}

public class ColectCarrotEvent : Event
{
    public ColectCarrotEvent() : base("ColectCarrotEvent") { }

    public int Carrot_score { set { SetParameter("carrotID", value); } }
}

public class CarrotCollectedEvent : Event
{
    public CarrotCollectedEvent() : base("carrotCollected") { }

    public int CollectibleId
    {
        set { SetParameter("collectible_id", value); }
    }

    public int CarrotsCount
    {
        set { SetParameter("carrots_count", value); }
    }

    public int CarrotsTotal
    {
        set { SetParameter("carrots_total", value); }
    }
}

public class CarrotCollectionSummaryEvent : Event
{
    public CarrotCollectionSummaryEvent() : base("CarrotCollectionSummary") { }

    public int CarrotsCount
    {
        set { SetParameter("carrots_count", value); }
    }

    public int CarrotsTotal
    {
        set { SetParameter("carrots_total", value); }
    }

    public bool AllThreeCollected
    {
        set { SetParameter("all_three_collected", value); }
    }
}

public class BubbleModeEvent : Event
{
    public BubbleModeEvent() : base("bubbleMode_Active") { }
}

public class grapplerEvent : Event
{
    public grapplerEvent() : base("grapplerEvent_Active") { }
}

public class HookNotUsedEvent : Event
{
    public HookNotUsedEvent() : base("hook_not_used") { }
}

public class HookActivatedEvent : Event
{
    public HookActivatedEvent() : base("HookActivated") { }

    public int HookId
    {
        set { SetParameter("hook_id", value); }
    }

    public string SectionId
    {
        set { SetParameter("section_id", value); }
    }

    public string ActivationResult
    {
        set { SetParameter("activation_result", value); }
    }

    public bool Used
    {
        set { SetParameter("used", value); }
    }
}

public class HookOpportunityResolvedEvent : Event
{
    public HookOpportunityResolvedEvent() : base("HookOpportunityResolved") { }

    public int HookId
    {
        set { SetParameter("hook_id", value); }
    }

    public string SectionId
    {
        set { SetParameter("section_id", value); }
    }

    public bool Used
    {
        set { SetParameter("used", value); }
    }
}

public class BalloonNotUsedEvent : Event
{
    public BalloonNotUsedEvent() : base("balloon_not_used") { }
}

public class BalloonActivatedEvent : Event
{
    public BalloonActivatedEvent() : base("BalloonActivated") { }

    public int OpportunityId
    {
        set { SetParameter("opportunity_id", value); }
    }

    public string SectionId
    {
        set { SetParameter("section_id", value); }
    }

    public bool Used
    {
        set { SetParameter("used", value); }
    }

    public float PositionX
    {
        set { SetParameter("position_x", value); }
    }

    public float PositionY
    {
        set { SetParameter("position_y", value); }
    }
}

public class BalloonOpportunityResolvedEvent : Event
{
    public BalloonOpportunityResolvedEvent() : base("BalloonOpportunityResolved") { }

    public int OpportunityId
    {
        set { SetParameter("opportunity_id", value); }
    }

    public string SectionId
    {
        set { SetParameter("section_id", value); }
    }

    public bool Used
    {
        set { SetParameter("used", value); }
    }

    public float PositionX
    {
        set { SetParameter("position_x", value); }
    }

    public float PositionY
    {
        set { SetParameter("position_y", value); }
    }
}

public class BowCollectedEvent : Event
{
    public BowCollectedEvent() : base("BowCollected") { }

    public int BowId
    {
        set { SetParameter("bow_id", value); }
    }

    public string SectionId
    {
        set { SetParameter("section_id", value); }
    }

    public float PositionX
    {
        set { SetParameter("position_x", value); }
    }

    public float PositionY
    {
        set { SetParameter("position_y", value); }
    }
}

public class PlayersMaxTimeEvent : Event
{
    public PlayersMaxTimeEvent() : base("players_max_time") { }

    public float TimeSeconds
    {
        set { SetParameter("time_seconds", value); }
    }

    public float X
    {
        set { SetParameter("x_coord", value); }
    }

    public float Y
    {
        set { SetParameter("y_coord", value); }
    }
}

public class AverageTimeEvent : Event
{
    public AverageTimeEvent() : base("average_time") { }

    public int SectorId
    {
        set { SetParameter("sector_id", value); }
    }

    public float TimeSeconds
    {
        set { SetParameter("time_seconds", value); }
    }
}

public class CheckpointReachedEvent : Event
{
    public CheckpointReachedEvent() : base("CheckpointReached") { }

    public int CheckpointId
    {
        set { SetParameter("checkpoint_id", value); }
    }

    public string SectionId
    {
        set { SetParameter("section_id", value); }
    }

    public float ElapsedSeconds
    {
        set { SetParameter("elapsed_seconds", value); }
    }
}

public class CheckpointSkippedEvent : Event
{
    public CheckpointSkippedEvent() : base("CheckpointSkipped") { }

    public int CheckpointId
    {
        set { SetParameter("checkpoint_id", value); }
    }

    public int NextCheckpointId
    {
        set { SetParameter("next_checkpoint_id", value); }
    }

    public float PositionX
    {
        set { SetParameter("position_x", value); }
    }

    public float PositionY
    {
        set { SetParameter("position_y", value); }
    }
}

public class LevelSelectTimeEvent : Event
{
    public LevelSelectTimeEvent() : base("level_select_time") { }

    public float TimeSeconds
    {
        set { SetParameter("time_seconds", value); }
    }
}

public class LevelSelectionCompletedEvent : Event
{
    public LevelSelectionCompletedEvent() : base("LevelSelectionCompleted") { }

    public string SelectedLevelId
    {
        set { SetParameter("selected_level_id", value); }
    }

    public float DurationSeconds
    {
        set { SetParameter("duration_seconds", value); }
    }

    public string SessionId
    {
        set { SetParameter("session_id", value); }
    }
}

public class GreenBubbleEvent : Event
{
    public GreenBubbleEvent() : base("green_bubbles") { }

    public int BubbleId
    {
        set { SetParameter("bubble_id", value); }
    }
}

public class GreenBubbleTouchedEvent : Event
{
    public GreenBubbleTouchedEvent() : base("GreenBubbleTouched") { }

    public int BubbleId
    {
        set { SetParameter("bubble_id", value); }
    }

    public string SectionId
    {
        set { SetParameter("section_id", value); }
    }

    public bool LifeLost
    {
        set { SetParameter("life_lost", value); }
    }

    public float PositionX
    {
        set { SetParameter("position_x", value); }
    }

    public float PositionY
    {
        set { SetParameter("position_y", value); }
    }
}

// nuevos eventos
public class LevelRunStartedEvent : Event
{
    public LevelRunStartedEvent() : base("LevelRunStarted") { }

    public string RunId
    {
        set { SetParameter("run_id", value); }
    }
}

public class LevelRunEndedEvent : Event
{
    public LevelRunEndedEvent() : base("LevelRunEnded") { }

    public string RunId
    {
        set { SetParameter("run_id", value); }
    }

    public string LevelId
    {
        set { SetParameter("level_id", value); }
    }

    public float DurationSeconds
    {
        set { SetParameter("duration_seconds", value); }
    }

    public string EndReason
    {
        set { SetParameter("end_reason", value); }
    }

    public float LastPositionX
    {
        set { SetParameter("last_position_x", value); }
    }

    public float LastPositionY
    {
        set { SetParameter("last_position_y", value); }
    }

    public int LastCheckpointId
    {
        set { SetParameter("last_checkpoint_id", value); }
    }

    public string LastAction
    {
        set { SetParameter("last_action", value); }
    }

    public int LivesRemaining
    {
        set { SetParameter("lives_remaining", value); }
    }
}