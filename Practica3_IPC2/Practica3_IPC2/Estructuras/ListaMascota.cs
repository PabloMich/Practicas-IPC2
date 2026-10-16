using System;
using Practica3_IPC2.Models;

namespace Practica3_IPC2.Estructuras
{
    public class ListaMascotas
    {
        private Nodo? cabeza;

        public ListaMascotas()
        {
            cabeza = null;
        }
        
        public void Agregar(Mascota mascota)
        {
            Nodo nuevo = new Nodo(mascota);

            if (cabeza == null)
            {
                cabeza = nuevo;
                return;
            }

            Nodo actual = cabeza;

            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }

            actual.Siguiente = nuevo;
        }

        // Buscar por código único
        public Mascota? Buscar(string codigo)
        {
            Nodo? actual = cabeza;

            while (actual != null)
            {
                if (actual.Dato.CodigoUnico == codigo)
                {
                    return actual.Dato;
                }

                actual = actual.Siguiente;
            }

            return null;
        }

        // Eliminar
        public bool Eliminar(string codigo)
        {
            if (cabeza == null)
            {
                return false;
            }

            if (cabeza.Dato.CodigoUnico == codigo)
            {
                cabeza = cabeza.Siguiente;
                return true;
            }

            Nodo actual = cabeza;

            while (actual.Siguiente != null)
            {
                if (actual.Siguiente.Dato.CodigoUnico == codigo)
                {
                    actual.Siguiente = actual.Siguiente.Siguiente;
                    return true;
                }

                actual = actual.Siguiente;
            }

            return false;
        }
        
        public void Recorrer(Action<Mascota> accion)
        {
            Nodo? actual = cabeza;

            while (actual != null)
            {
                accion(actual.Dato);
                actual = actual.Siguiente;
            }
        }
        
        public bool EstaVacia()
        {
            return cabeza == null;
        }
        
        public Nodo? ObtenerPrimero()
        {
            return cabeza;
        }

        
    }
}
