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
    public ColectCarrotEvent() : base("ColectCarrot") { }

    public int Carrot_score { set { SetParameter("carrotID", value); } }
}