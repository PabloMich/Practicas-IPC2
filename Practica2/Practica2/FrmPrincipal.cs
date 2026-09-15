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

        ActualizarTiempoTotal();

    }

    private void ActualizarTiempoTotal()
    {
        int tiempo = cola.ObtenerTiempoTotal();

        lblTiempoTotal.Text = "Tiempo restante: " + tiempo + " minutos";
    }


    private void label1_Click(object sender, EventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void btnReproducir_Click(object sender, EventArgs e)
    {
        Cancion? cancion = cola.Desencolar();

        if (cancion == null)
        {
            MessageBox.Show("La cola de reproducción está vacía.");
            return;
        }

        lblTitulo.Text = "Título" + cancion.Titulo;
        lblArtista.Text = "Artista" + cancion.Artista;
        lblGenero.Text = "Género" + cancion.Genero;
        lblDuracion.Text = "Duración: " + cancion.Duracion + " minutos";
        
        ActualizarTiempoTotal();
    }

    private void btnBuscar_Click(object sender, EventArgs e)
    {
        string titulo = txtBuscar.Text.Trim();

        if (titulo == "")
        {
            MessageBox.Show("Ingrese el título de una canción.");
            return;
        }
        
        Cancion? cancion = arbol.Buscar(titulo);

        if (cancion == null)
        {
            lblResultado.Text = "Canción no encontrada.";
            return;
        }
        
        lblResultado.Text = "Título: " + cancion.Titulo + "\n" +
                            "Artista: " + cancion.Artista + "\n" +
                            "Género: " + cancion.Genero + "\n" +
                            "Duración: " + cancion.Duracion + " minutos";
    }
}