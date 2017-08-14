using System;
using System.Collections.Generic;
using System.IO;

namespace targets
{
    public class MissionUtils
    {
        static string basePath = Path.Combine("missions", "Multi", "Fatal", "Campaign2");
        static string targetMissionFolder = Path.Combine(basePath, "targets");
        static string spawnpointFolder = Path.Combine(basePath, "spawnpoints");

        public static List<string> ReadTargets(){
            var targets = new List<string>();
            var currentDirectory = Directory.GetCurrentDirectory();
            var targetFilePath = Path.Combine(currentDirectory, "thebattle_targets.txt");
            FileStream targetFile = File.Open(targetFilePath, FileMode.Open);
            StreamReader sr = new StreamReader(targetFile);
            while(!sr.EndOfStream){
                targets.Add(sr.ReadLine().Trim());
            }
            return targets;
        }
    }
}