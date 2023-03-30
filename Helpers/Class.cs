using Newtonsoft.Json.Linq;
using ChallengeSGB.Models;

namespace ChallengeSGB.Helpers
{
    public class Promedy
    {
        public string reference { get; set; }
        public float value { get; set; }
        public int iteration { get; set; }

        public Promedy(string _reference, float _value, int _iteration)
        {
            reference = _reference;
            value = _value;
            iteration = _iteration;
        }
    }
    public class MoviesPerPeriod
    {
        public float moviesSeen {get; set;}
        public string period { get; set; }
        public MoviesPerPeriod(string _period, float _moviesSeen)
        {
            moviesSeen = _moviesSeen;
            period = _period;
        }
    }

    public class MoviesPerPeriodAndSex
    {
        public string sex { get; set; }
        public List<MoviesPerPeriod> moviesPerPeriod { get; set; }

        public MoviesPerPeriodAndSex(string _sex, MoviesPerPeriod[] _moviesPerPeriod)
        {
            sex = _sex;
            moviesPerPeriod = _moviesPerPeriod.ToList();
        }
    }

    public class PromedyResults
    {
        public List<Encuesta> encuestas { get; set; }
        public float viewsPerUser { get; set; }
        public List<Promedy> moviesByAge { get; set; }
        public List<Promedy> moviesBySex { get; set; }
        public List<MoviesPerPeriod> moviesPerPeriod { get; set; }
        public List<MoviesPerPeriodAndSex> moviesPerPeriodAndSex { get; set; }
    }
}
