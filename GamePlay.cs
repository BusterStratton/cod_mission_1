using System;
using System.Collections.Generic;

public class GamePlay
{
    internal static void gpHUDLogCenter(string message)
    {
        Console.WriteLine($"gpHUDLogCenter: {message}");
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
}