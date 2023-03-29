using System;
using System.Collections.Generic;

namespace ChallengeSGB.Models;

public partial class Encuesta
{
    public int Id { get; set; }

    public int? NumeroUsuario { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string? Sexo { get; set; }

    public int? Periodo { get; set; }

    public int? CantidadPeliculas { get; set; }
}
