using System;
using System.Collections.Generic;
using System.Linq;

namespace targets
{
    class Program
    {
        static void Main(string[] args)
        {
            var rng = new Random();

            // Step 1 - Build up some objectives
            var objectives = new List<AirfieldTarget>(){
                new AirfieldTarget("Abbeville Fuel", Objective.AbbevilleFuel, Team.German, 0, 10000),
                new AirfieldTarget("Arras Fuel", Objective.ArrasFuel, Team.German, 0, 10000),
                new AirfieldTarget("Bapaume Railyard", Objective.BapaumeRailyard, Team.German, 0, 10000),
                new AirfieldTarget("LeTouque Fuel", Objective.LeTouqueFuel, Team.German, 0, 10000),
                new AirfieldTarget("Abbeville Airfield", Objective.AbbevilleAirfield, Team.German, 0, 10000),
                new AirfieldTarget("Ligescourt Airfield", Objective.LigescourtAirfield, Team.German, 0, 10000),
                new AirfieldTarget("Barley Airfield", Objective.BarleyAirfield, Team.German, 0, 10000),
                new AirfieldTarget("Tramcourt Airfield", Objective.TramcourtAirfield, Team.German, 0, 10000),
                new AirfieldTarget("Arras ST Airfield", Objective.ArrasSTAirfield, Team.German, 0, 10000),
                new AirfieldTarget("Cremont Airfield", Objective.CremontAirfield, Team.German, 0, 10000),
                new AirfieldTarget("Ywrench Airfield", Objective.YwrenchAirfield, Team.German, 0, 10000),
                new AirfieldTarget("Poix Nord Airfield", Objective.PoixNordAirfield, Team.British, 0, 10000),
                new AirfieldTarget("Dieppe Airfield", Objective.DieppeAirfield, Team.British, 0, 10000),
                new AirfieldTarget("Grandvilliers Airfield", Objective.GrandvilliersAirfield, Team.British, 0, 10000),
                new AirfieldTarget("Brambos Airfield", Objective.BrambosAirfield, Team.British, 0, 10000),
                new AirfieldTarget("Rosiers Airfield", Objective.RosiersAirfield, Team.British, 0, 10000),
                new AirfieldTarget("Montdidea Airfield", Objective.MontdideaAirfield, Team.British, 0, 10000),
                new AirfieldTarget("Haute Airfield", Objective.HauteAirfield, Team.British, 0, 10000),
                new AirfieldTarget("Lehavre Airfield", Objective.LehavreAirfield, Team.British, 0, 10000),
                new AirfieldTarget("Rouen Airfield", Objective.RouenAirfield, Team.British, 0, 10000),
                new AirfieldTarget("Crepon Airfield", Objective.CreponAirfield, Team.British, 0, 10000),
                new AirfieldTarget("LeHavre Fuel 0", Objective.LeHavreFuel0, Team.British, 0, 10000),
                new AirfieldTarget("LeHavre Fuel 2", Objective.LeHavreFuel2, Team.British, 0, 10000),
                new AirfieldTarget("LeHavre Fuel 3", Objective.LeHavreFuel3, Team.British, 0, 10000),
                new AirfieldTarget("Rouen Fuel", Objective.RouenFuel, Team.British, 0, 10000)
            };

            // Step 2 - Create the teams
            var blueTeam = new ObjectiveTeam(Team.British, objectives.Where(s=> s.Team == Team.British));
            var redTeam = new ObjectiveTeam(Team.German, objectives.Where(s=> s.Team == Team.German));

            


            // Step 3 - Loop through the gpAirports and match them up with the objectives we created.
            foreach (AiAirport ap in GamePlay.gpAirports())
            {
                // This assumes the ObjectiveName and Airport name will match.. Probably need to tweak this statement
                var field = objectives.FirstOrDefault( s=> s.ObjectiveName.ToString() == ap.Name() );
                
                // We found a match
                if( field != null ){
                    field.Airport = ap;
                }
            }

            // Step 4 - We should have linked all the objectives
            var missingAirports = objectives.Where( s => s.Airport == null);
            if( missingAirports.Count() > 0 ){
                foreach(AirfieldTarget target in missingAirports){
                    Console.WriteLine(target.ObjectiveName.ToString() + " is missing");
                }
            }

            foreach(AirfieldTarget target in objectives.Where(t => t.Airport != null)){
                target.BombDropped(new Point3d(), 7000);
            }

        }
    }
}
