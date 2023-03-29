namespace ChallengeSGB.Models
{
    public class SerieMoviesPerPeriod
    {
       // name: 'Reggane',
         //   data: [16.0, 18.2, 23.1, 27.9, 32.2, 36.4, 39.8, 38.4, 35.5, 29.2,
           //     22.0, 17.8]
        public string name { get; set; }
        public int[] data { get; set; }

        public SerieMoviesPerPeriod(string _name, int[] _data)
        {
            this.name = _name;
            this.data = _data;
        }
    }
}
