using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace targets
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));

            var rng = new Random();

            // Step 1 - Build up some objectives
            var objectives = new List<AirfieldTarget>(){
 var objectives = new List<AirfieldTarget>(){
                new AirfieldTarget("Abbeville Fuel", Objective.AbbevilleFuel, Team.British, 0, 10000),
                new AirfieldTarget("Arras Fuel", Objective.ArrasFuel, Team.British, 0, 10000),
                new AirfieldTarget("Bapaume Railyard", Objective.BapaumeRailyard, Team.British, 0, 10000),
                new AirfieldTarget("LeTouque Fuel", Objective.LeTouqueFuel, Team.British, 0, 10000),
                new AirfieldTarget("Abbeville Airfield", Objective.AbbevilleAirfield, Team.British, 0, 10000),
                new AirfieldTarget("Ligescourt Airfield", Objective.LigescourtAirfield, Team.British, 0, 10000),
                new AirfieldTarget("Barley Airfield", Objective.BarleyAirfield, Team.British, 0, 10000),
                new AirfieldTarget("Tramcourt Airfield", Objective.TramcourtAirfield, Team.British, 0, 10000),
                new AirfieldTarget("Arras ST Airfield", Objective.ArrasSTAirfield, Team.British, 0, 10000),
                new AirfieldTarget("Cremont Airfield", Objective.CremontAirfield, Team.British, 0, 10000),
                new AirfieldTarget("Ywrench Airfield", Objective.YwrenchAirfield, Team.British, 0, 10000),
                new AirfieldTarget("Poix Nord Airfield", Objective.PoixNordAirfield, Team.German, 0, 10000),
                new AirfieldTarget("Dieppe Airfield", Objective.DieppeAirfield, Team.German, 0, 10000),
                new AirfieldTarget("Grandvilliers Airfield", Objective.GrandvilliersAirfield, Team.German, 0, 10000),
                new AirfieldTarget("Brambos Airfield", Objective.BrambosAirfield, Team.German, 0, 10000),
                new AirfieldTarget("Rosiers Airfield", Objective.RosiersAirfield, Team.German, 0, 10000),
                new AirfieldTarget("Montdidea Airfield", Objective.MontdideaAirfield, Team.German, 0, 10000),
                new AirfieldTarget("Haute Airfield", Objective.HauteAirfield, Team.German, 0, 10000),
                new AirfieldTarget("Lehavre Airfield", Objective.LehavreAirfield, Team.German, 0, 10000),
                new AirfieldTarget("Rouen Airfield", Objective.RouenAirfield, Team.German, 0, 10000),
                new AirfieldTarget("Crepon Airfield", Objective.CreponAirfield, Team.British, 0, 10000),
                new AirfieldTarget("LeHavre Fuel 0", Objective.LeHavreFuel0, Team.German, 0, 10000),
                new AirfieldTarget("LeHavre Fuel 2", Objective.LeHavreFuel2, Team.German, 0, 10000),
                new AirfieldTarget("LeHavre Fuel 3", Objective.LeHavreFuel3, Team.German, 0, 10000),
                new AirfieldTarget("Rouen Fuel", Objective.RouenFuel, Team.German, 0, 10000)
            };

            // Step 2 - Create the teams
            var blueTeam = new ObjectiveTeam(Team.German, objectives.Where(s=> s.Team == Team.German));
            var redTeam = new ObjectiveTeam(Team.British, objectives.Where(s=> s.Team == Team.British));




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
