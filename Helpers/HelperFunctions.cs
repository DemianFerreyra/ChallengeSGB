using ChallengeSGB.Helpers;
using ChallengeSGB.Models;


public class HelperFunctions
{
    public static bool PeriodExists(string reference, Promedy[] periods)
    {
        foreach(Promedy p in periods)
        {
            if(p.reference == reference)
            {
                Console.WriteLine("lo contiene");
                return true;
            }
        }
        Console.WriteLine("no lo contiene");
        return false;
    }

    public static float GetPromedy(Encuesta[] encuestas, string caseToGetPromedy)
    {
        float total = 0;
        int iterations = 0;
        foreach (var encuesta in encuestas)
        {
            switch (caseToGetPromedy)
            {
                case "moviesByUser":
                    List<string> repeatedUsers = new List<string>();
                    //como el caso actual es peliculas por usuario, lo que hacemos es verificar si el usuario actual ya esta en la lista de repeatedUsers. Si no es el caso, entonces no se sumara iteracion, si es el caso, se sumara una iteracion, de manera tal que se saca el TOTAL de cada usuario sin importar el periodo, luego se suman y se dividen por la cantidad de usuarios 
                    if (repeatedUsers.Contains(encuesta.NumeroUsuario.ToString())){
                        total += encuesta.CantidadPeliculas ?? 0;
                    }
                    else
                    {
                        total += encuesta.CantidadPeliculas ?? 0;
                        repeatedUsers.Add(encuesta.NumeroUsuario.ToString());
                        iterations++;
                    }
                    break;
                default:
                    break;
            }
        }

        return total / iterations;
    }

    public static MoviesPerPeriod[] GetMoviesPerPeriod(Encuesta[] encuestas)
    {
        List<MoviesPerPeriod> moviesByPeriod = new List<MoviesPerPeriod>();

        List<Promedy> periods = new List<Promedy>();
        foreach (var encuesta in encuestas)
        {
            //en el caso actual lo que hacemos es guardar periodos (una clase con 2 propiedades, su referencia y su valor) cada vez que encontremos un periodo que no haya sido almacenado. En caso de que el periodo actual ya exista en esta lista, simplemente le sumamos la cantidad de peliculas.
            if (periods.Find(p => p.reference == encuesta.Periodo.ToString()) != null)
            {
                periods.Find(p => p.reference == encuesta.Periodo.ToString()).value += encuesta.CantidadPeliculas ?? 0;
            }
            else
            {
                periods.Add(new Promedy(encuesta.Periodo.ToString(), encuesta.CantidadPeliculas ?? 0));
            }
        }
        foreach(var period in periods)
        {
            moviesByPeriod.Add(new MoviesPerPeriod(period.reference, period.value));
        }

        foreach(var movies in moviesByPeriod)
        {
            Console.WriteLine($"peliculasPorPeriodo actual = {movies.period}:{movies.moviesSeen}");
        }
        return moviesByPeriod.ToArray();
    }
}