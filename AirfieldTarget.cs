using System;

public enum Objective
{
    abbevillefuel,
    arrasfuel,
    bapaumerailyard,
    letouquefuel,
    abbevilleairfield,
    ligescourtairfield,
    barleyairfield,
    tramcourtairfield,
    arrasstairfield,
    cremontairfield,
    ywrenchairfield,
    poixnordairfield,
    dieppeairfield,
    grandvilliersairfield,
    brambosairfield,
    rosiersairfield,
    montdideaairfield,
    hauteairfield,
    lehavreairfield,
    rouenairfield,
    creponairfield,
    lehavrefuel0,
    lehavrefuel2,
    lehavrefuel3,
    rouenfuel
}
public class AirfieldTarget
{
    // Public Properties
    public AiAirport Airport { get; set; }
    public Team Team { get; set; }
    public string InGameName { get; set; }
    public Objective ObjectiveName { get; set; }
    public double Damage { get; set; }
    public double DamageRequired { get; set; }
    public bool Destroyed { 
        get {
            return Damage >= DamageRequired;
        }
    }
    public string PercentDestroyed {
        get {
            return Destroyed || DamageRequired.Equals(0) ? "100" : (Damage / DamageRequired * 100).ToString("0");
        }
    }

    // Constructor
    public AirfieldTarget(string inGameName, Objective objectiveName, Team team, double damage = 0, double damageRequired = 0)
    {
       InGameName = inGameName;
       ObjectiveName = objectiveName;
       Team = team;
       Damage = damage;
       DamageRequired = damageRequired;
    }

    private bool PointIsInDamageRadius(Point3d pos)
    {
        return Airport.Pos().distance(pos) <= Airport.FieldR();
    }

    // Return true when a dropped bomb hits a target that has not been destroyed
    public bool BombDropped(Point3d pos, double mass)
    {
        if(Airport == null){
            Console.WriteLine($"Cannot drop a bomb on {ObjectiveName.ToString()}. AiAirport not linked.");
            return false;
        }
        
        // Skip if the airfied is destroyed
        if (Destroyed){
            return false;
        }

        // This is a hit
        if (PointIsInDamageRadius(pos))
        {
            // Add the damage
            Damage += mass;

            // Message User
            var message = $"{InGameName} is {PercentDestroyed}% destroyed";
            GamePlay.gpHUDLogCenter(message);
            return true;
        }

        // Miss
        return false;
    }
}