using Practica2.Models;
using Practica2.Estructuras;
using Practica2.Services;

namespace Practica2;



public partial class FrmPrincipal : Form
{

    private ColaReproduccion cola;
    private ArbolBinario arbol;
    
    public FrmPrincipal()
    {
        InitializeComponent();
        
        cola = new ColaReproduccion();
        arbol = new ArbolBinario();

        CargarCanciones();

    }

    public void CargarCanciones()
    {
        CargadorCanciones cargador = new CargadorCanciones();

        string ruta = Path.Combine(AppContext.BaseDirectory, "Data", "canciones.json");

        Cancion[] canciones = cargador.Cargar(ruta);
        
        // Verificamos si se cargaron canciones
        if (canciones.Length == 0)
        {
            MessageBox.Show(
                "No se encontraron canciones.\n\nRuta utilizada:\n" + ruta
            );

            return;
        }

        foreach (Cancion cancion in canciones)
        {
            cola.Encolar(cancion);
            arbol.Insertar(cancion);
        }

        MessageBox.Show("Canciones cargadas correctamente.\n" +
                        "Cantidad: " + canciones.Length + "\n" +
                        "Tiempo total: " +
                        cola.ObtenerTiempoTotal() +
                        "minutos.");
    }
    
}