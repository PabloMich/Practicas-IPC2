using System.Text.Json;
using Practica2.Models;

namespace Practica2.Services;

public class CargadorCanciones
{
    public Cancion[] Cargar(string ruta)
    {
        if (!File.Exists(ruta))
        {
            return Array.Empty<Cancion>();
        }
        
        string contenidoJson = File.ReadAllText(ruta);
        
        Cancion[]? canciones = JsonSerializer.Deserialize<Cancion[]>(contenidoJson);

        if (canciones == null)
        {
            return Array.Empty<Cancion>();
        }
        
        return canciones;
    }
}