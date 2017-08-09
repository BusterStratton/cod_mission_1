using System;
using System.Collections.Generic;

public class GamePlay
{
    internal static void gpHUDLogCenter(string message)//question below
    {
        Console.WriteLine($"gpHUDLogCenter: {message}");//question below
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
