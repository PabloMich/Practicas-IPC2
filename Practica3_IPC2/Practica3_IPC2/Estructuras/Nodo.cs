using Practica3_IPC2.Models;

namespace Practica3_IPC2.Estructuras
{
    public class Nodo
    {
        public Mascota Dato { get; set; }
        public Nodo? Siguiente { get; set; }

        // Constructor
        public Nodo(Mascota mascota)
        {
            Dato = mascota;
            Siguiente = null;
        }
    }
}