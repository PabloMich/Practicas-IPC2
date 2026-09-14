namespace Practica2.Models;

public class Cancion
{
    public string Titulo { get; set; }
    public string Artista { get; set; }
    public string Genero { get; set; }
    public int Duracion { get; set; }

    public Cancion(string titulo, string artista, string genero, int duracion)
    {
        Titulo = titulo;
        Artista = artista;
        Genero = genero;
        Duracion = duracion;
    }
}