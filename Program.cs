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
                new AirfieldTarget("Abbeville Fuel", Objective.abbevillefuel, Team.German, 0, 10000),
                new AirfieldTarget("Arras Fuel", Objective.arrasfuel, Team.German, 0, 10000),
                new AirfieldTarget("Bapaume Railyard", Objective.bapaumerailyard, Team.German, 0, 10000),
                new AirfieldTarget("LeTouque Fuel", Objective.letouquefuel, Team.German, 0, 10000),
                new AirfieldTarget("Abbeville Airfield", Objective.abbevilleairfield, Team.German, 0, 10000),
                new AirfieldTarget("Ligescourt Airfield", Objective.ligescourtairfield, Team.German, 0, 10000),
                new AirfieldTarget("Barley Airfield", Objective.barleyairfield, Team.German, 0, 10000),
                new AirfieldTarget("Tramcourt Airfield", Objective.tramcourtairfield, Team.German, 0, 10000),
                new AirfieldTarget("Arras ST Airfield", Objective.arrasstairfield, Team.German, 0, 10000),
                new AirfieldTarget("Cremont Airfield", Objective.cremontairfield, Team.German, 0, 10000),
                new AirfieldTarget("Ywrench Airfield", Objective.ywrenchairfield, Team.German, 0, 10000),
                new AirfieldTarget("Poix Nord Airfield", Objective.poixnordairfield, Team.British, 0, 10000),
                new AirfieldTarget("Dieppe Airfield", Objective.dieppeairfield, Team.British, 0, 10000),
                new AirfieldTarget("Grandvilliers Airfield", Objective.grandvilliersairfield, Team.British, 0, 10000),
                new AirfieldTarget("Brambos Airfield", Objective.brambosairfield, Team.British, 0, 10000),
                new AirfieldTarget("Rosiers Airfield", Objective.rosiersairfield, Team.British, 0, 10000),
                new AirfieldTarget("Montdidea Airfield", Objective.montdideaairfield, Team.British, 0, 10000),
                new AirfieldTarget("Haute Airfield", Objective.hauteairfield, Team.British, 0, 10000),
                new AirfieldTarget("Lehavre Airfield", Objective.lehavreairfield, Team.British, 0, 10000),
                new AirfieldTarget("Rouen Airfield", Objective.rouenairfield, Team.British, 0, 10000),
                new AirfieldTarget("Crepon Airfield", Objective.creponairfield, Team.British, 0, 10000),
                new AirfieldTarget("LeHavre Fuel 0", Objective.lehavrefuel0, Team.British, 0, 10000),
                new AirfieldTarget("LeHavre Fuel 2", Objective.lehavrefuel2, Team.British, 0, 10000),
                new AirfieldTarget("LeHavre Fuel 3", Objective.lehavrefuel3, Team.British, 0, 10000),
                new AirfieldTarget("Rouen Fuel", Objective.rouenfuel, Team.British, 0, 10000)
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
