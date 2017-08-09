using System.Collections.Generic;

public enum Team{
    British,
    German
}

public class ObjectiveTeam
{
    public Team Team { get; set; }
    public IEnumerable<AirfieldTarget> Objectives {get; set;}

    public ObjectiveTeam( Team team, IEnumerable<AirfieldTarget> objectives){
        Team = team;
        Objectives = objectives;
    }
}