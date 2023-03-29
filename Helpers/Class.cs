using Newtonsoft.Json.Linq;
using ChallengeSGB.Models;

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
    public class Results
    {
        public List<Encuesta> encuestas;
        public float viewsPerUser;

        public Results(List<Encuesta> _encuestas, float _viewsPerUser)
        {
            encuestas = _encuestas;
            viewsPerUser = _viewsPerUser;
        }
    }
}
