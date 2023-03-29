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
        float promedy = 0;
        int iterations = 0;
        foreach (var encuesta in encuestas)
        {
            switch (caseToGetPromedy)
            {
                case "moviesByUser":
                    List<string> repeatedUsers = new List<string>();
                    //como el caso actual es peliculas por usuario, lo que hacemos es verificar si el usuario actual ya esta en la lista de repeatedUsers. Si no es el caso, entonces no se sumara iteracion, si es el caso, se sumara una iteracion, de manera tal que se saca el TOTAL de cada usuario sin importar el periodo, luego se suman y se dividen por la cantidad de usuarios 
                    if (repeatedUsers.Contains(encuesta.NumeroUsuario.ToString())){
                        promedy += encuesta.CantidadPeliculas ?? 0;
                    }
                    else
                    {
                        promedy += encuesta.CantidadPeliculas ?? 0;
                        repeatedUsers.Add(encuesta.NumeroUsuario.ToString());
                        iterations++;
                    }
                    break;

                default:
                    break;
            }
        }

        return promedy / iterations;
    }
}