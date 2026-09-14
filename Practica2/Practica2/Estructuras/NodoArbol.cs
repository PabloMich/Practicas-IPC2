using Practica2.Models;

namespace Practica2.Estructuras;

public class NodoArbol
{
    public Cancion Cancion { get; set; }
    public NodoArbol? Izquierda { get; set; }
    public NodoArbol? Derecha { get; set; }

    public NodoArbol(Cancion cancion)
    {
        Cancion = cancion;
        Izquierda = null;
        Derecha = null;
    }
}