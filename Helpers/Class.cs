using Newtonsoft.Json.Linq;
using ChallengeSGB.Models;

namespace ChallengeSGB.Helpers
{
    public class Promedy
    {
        public string reference { get; set; }
        public int value { get; set; }

        public Promedy(string _reference, int _value)
        {
            reference = _reference;
            value = _value;
        }
    }
    public class MoviesPerPeriod
    {
        public int moviesSeen {get; set;}
        public string period { get; set; }
        public MoviesPerPeriod(string _period, int _moviesSeen)
        {
            moviesSeen = _moviesSeen;
            period = _period;
        }
    }
    public class PromedyResults
    {
        public List<Encuesta> encuestas { get; set; }
        public float viewsPerUser { get; set; }
        public List<Promedy> moviesByAge { get; set; }
        public List<MoviesPerPeriod> moviesPerPeriod { get; set; }

        //public PromedyResults(List<Encuesta> _encuestas, float _viewsPerUser, List<Promedy> _moviesByAge, List<MoviesPerPeriod> _moviesPerPeriod)
        //{
        //    encuestas = _encuestas;
        //    viewsPerUser = _viewsPerUser;
        //    moviesByAge = _moviesByAge;
        //    moviesPerPeriod = _moviesPerPeriod;
        //}
    }
}
