using ChallengeSGB.Helpers;


public class HelperFunctions
{
    public static bool PeriodExists(string period, Period[] periods)
    {
        foreach(Period p in periods)
        {
            if(p.period == period)
            {
                Console.WriteLine("lo contiene");
                return true;
            }
        }
        Console.WriteLine("no lo contiene");
        return false;
    }
}