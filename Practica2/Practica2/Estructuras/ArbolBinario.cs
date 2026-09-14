using Practica2.Models;

namespace Practica2.Estructuras;

public class ArbolBinario
{
    private NodoArbol? raiz;
    
    public ArbolBinario()
    {
        raiz = null;
    }

    public void Insertar(Cancion cancion)
    {
        NodoArbol nuevoNodo = new NodoArbol(cancion);

        if (raiz == null)
        {
            raiz = nuevoNodo;
            return;
        }
        
        NodoArbol actual = raiz;

        while (true)
        {
            int comparacion = string.Compare(
                cancion.Titulo,
                actual.Cancion.Titulo,
                StringComparison.OrdinalIgnoreCase
                );

            if (comparacion < 0)
            {
                if (actual.Izquierda == null)
                {
                    actual.Izquierda = nuevoNodo;
                    break;
                }
                
                actual = actual.Izquierda;
            }
            else
            {
                if (actual.Derecha == null)
                {
                    actual.Derecha = nuevoNodo;
                    break;
                }
                
                actual = actual.Derecha;
            }
        }
    }

    public Cancion? Buscar(string titulo)
    {
        NodoArbol? actual = raiz;

        while (actual != null)
        {
            int comparacion = string.Compare(
                titulo,
                actual.Cancion.Titulo,
                StringComparison.OrdinalIgnoreCase
                );

            if (comparacion == 0)
            {
                return actual.Cancion;
            }

            if (comparacion < 0)
            {
                actual = actual.Izquierda;
            }
            else
            {
                actual = actual.Derecha;
            }
        }
        return null;
    }

    public NodoArbol? ObtenerRaiz()
    {
        return raiz;
    }
}