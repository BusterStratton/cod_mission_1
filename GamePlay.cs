using System;
using System.Collections.Generic;

public class GamePlay
{
    internal static void gpHUDLogCenter(string message)
    {
        Console.WriteLine($"gpHUDLogCenter: {message}");
    }

    internal static void gpLogServer(Player[] to, object data, object[] third)
    {
        Console.WriteLine($"gpHUDLogCenter: {(string)data}");
    }

    internal static IEnumerable<AiAirport> gpAirports()
    {
        return new List<AiAirport>(){
            new AiAirport("MontdideaAirfield"),
            new AiAirport(""),
            new AiAirport(""),
            new AiAirport(""),
            new AiAirport(""),
            new AiAirport(""),
            new AiAirport("")
        };
    }

    internal static void gpPostMissionLoad(string mission)
    {
        throw new NotImplementedException();
    }
}