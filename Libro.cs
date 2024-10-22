using System;
using System.Collections.Generic;

namespace WebAPICrud.Models;

public partial class Libro
{
    public int IdLibro { get; set; }

    public int? Isbn { get; set; }

    public string? Nombre { get; set; }

    public string? Editorial { get; set; }

    public DateOnly? Fecha { get; set; }

    public int? Precio { get; set; }
}
