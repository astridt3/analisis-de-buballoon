// analytic custom events classes for overrides

public class PlayerDiedEvent : Unity.Services.Analytics.Event
{
    public PlayerDiedEvent() : base("player_died") { }

    //public int player_score { set { SetParameter("player_score", value); } }
    //public int jumps { set { SetParameter("player_jumps", value); } }
    //public int obstaclesHit { set { SetParameter("obstacles_hit", value); } }
    //public string deathReason { set { SetParameter("death_reason", value); } }
    //public int milestone { set { SetParameter("milestone", value); } }
}

public class ColectCarrotEvent : Unity.Services.Analytics.Event
{
    public ColectCarrotEvent() : base("ColectCarrotEvent") { }

    public int Carrot_score { set { SetParameter("carrotID", value); } }
}

public class PlayerVictoryEvent : Unity.Services.Analytics.Event
{
    public PlayerVictoryEvent() : base("player_won") { }
}
public class BubbleModeEvent : Unity.Services.Analytics.Event
{
    public BubbleModeEvent() : base("bubbleMode_Active") { }
}
public class grapplerEvent : Unity.Services.Analytics.Event
{
    public grapplerEvent() : base("grapplerEvent_Active") { }
}
public class coinEvent : Unity.Services.Analytics.Event
{
    public coinEvent() : base("coinID") { }
}
public class emptyHeartCountEvent : Unity.Services.Analytics.Event
{
    public emptyHeartCountEvent() : base("emptyHeart_Count") { }
}