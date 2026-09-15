using System.Text.Json.Serialization;

namespace Practica2.Models;

public class Cancion
{
    [JsonPropertyName("titulo")]
    public string Titulo { get; set; }

    [JsonPropertyName("artista")]
    public string Artista { get; set; }

    [JsonPropertyName("genero")]
    public string Genero { get; set; }

    [JsonPropertyName("duracion")]
    public int Duracion { get; set; }
    
    public Cancion()
    {
        Titulo = "";
        Artista = "";
        Genero = "";
        Duracion = 0;
    }

    public Cancion(
        string titulo,
        string artista,
        string genero,
        int duracion
    )
    {
        Titulo = titulo;
        Artista = artista;
        Genero = genero;
        Duracion = duracion;
    }
}