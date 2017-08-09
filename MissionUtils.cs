using System;
using System.Collections.Generic;
using System.IO;

namespace targets
{
    public class MissionUtils
    {
        static string basePath = Path.Combine("missions", "Multi", "Fatal", "Campaign2");
        static string targetFile = Path.Combine(basePath, "thebattle_targets.txt");

        static string targetMissionFolder = Path.Combine(basePath, "targets");
        static string spawnpointFolder = Path.Combine(basePath, "spawnpoints");

        public static void ReadTargets(){
            var targetFilePath = Path.Combine(Directory.GetCurrentDirectory(), "thebattle_targets.txt");
            FileStream targets = File.Open(targetFilePath, FileMode.Open);
            StreamReader sr = new StreamReader(targets);
        }
    }
}