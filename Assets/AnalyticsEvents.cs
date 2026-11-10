using Unity.Services.Analytics;

// analytic custom events classes for overrides

public class PlayerDiedEvent : Event
{
    public PlayerDiedEvent() : base("player_died") { }
}

public class LostLifeEvent : Event
{
    public LostLifeEvent() : base("lost_life") { }
}

public class DeathCoordinatesEvent : Event
{
    public DeathCoordinatesEvent() : base("death_coordinates") { }

    public float X
    {
        set { SetParameter("x", value); }
    }

    public float Y
    {
        set { SetParameter("y", value); }
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

public class BalloonNotUsedEvent : Event
{
    public BalloonNotUsedEvent() : base("balloon_not_used") { }
}

public class coinEvent : Event
{
    public coinEvent() : base("obtained_bows") { }
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
        set { SetParameter("x", value); }
    }

    public float Y
    {
        set { SetParameter("y", value); }
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

public class CheckpointSkippedEvent : Event
{
    public CheckpointSkippedEvent() : base("checkpoint_skipped") { }

    public int CheckpointId
    {
        set { SetParameter("checkpoint_id", value); }
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

public class GreenBubbleEvent : Event
{
    public GreenBubbleEvent() : base("green_bubbles") { }

    public int BubbleId
    {
        set { SetParameter("bubble_id", value); }
    }
}