using Newtonsoft.Json.Linq;

namespace ChallengeSGB.Helpers
{
    public class Promedy
    {
        public string reference;
        public int value;

        public Promedy(string _reference, int _value)
        {
            reference = _reference;
            value = _value;
        }
    }
    public class MoviesPerPeriod
    {
        public int moviesSeen;
        public string period;
        public MoviesPerPeriod(string _period, int _moviesSeen)
        {
            moviesSeen = _moviesSeen;
            period = _period;
        }
    }
}
