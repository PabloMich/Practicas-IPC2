using Practica2.Models;

namespace Practica2.Estructuras;

public class ColaReproduccion
{
    private NodoCola? frente;
    private NodoCola? final;

    public ColaReproduccion()
    {
        frente = null;
        final = null;
    }

    public void Encolar(Cancion cancion)
    {
        NodoCola nuevoNodo = new NodoCola(cancion);

        if (frente != null)
        {
            frente = nuevoNodo;
            final = nuevoNodo;
        }
        else
        {
            final!.Siguiente = nuevoNodo;
            final = nuevoNodo;
        }
    }

    public Cancion? Desencolar()
    {
        if (frente == null)
        {
            return null;
        }

        Cancion cancion = frente.Cancion;

        frente = frente.Siguiente;

        if (frente == null)
        {
            final = null;
        }
        
        return cancion;
    }

    public bool EstaVacia()
    {
        return frente == null;
    }

    public int ObtenerTiempoTotal()
    {
        int total = 0;
        
        NodoCola? actual = frente;

        while (actual != null)
        {
            total += actual.Cancion.Duracion;
            actual = actual.Siguiente;
        }
        return total;
    }
}