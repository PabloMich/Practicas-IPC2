using Practica2.Models;
using Practica2.Estructuras;
using Practica2.Services;
using Practica2.Graphviz;

namespace Practica2;

public partial class FrmPrincipal : Form
{
    private ColaReproduccion cola;
    private ArbolBinario arbol;
    private GraphvizService graphviz;

    public FrmPrincipal()
    {
        InitializeComponent();

        AplicarEstilos();

        lblTitulo.Text = "Ninguna canción reproduciéndose";
        lblArtista.Text = "Selecciona Reproducir para comenzar";
        lblGenero.Text = "";
        lblDuracion.Text = "";
        lblResultado.Text = "";
        
        btnReproducir.Text = "▶  REPRODUCIR";

        cola = new ColaReproduccion();
        arbol = new ArbolBinario();
        graphviz = new GraphvizService();
        
        pnlCancionActual.BackColor = Color.FromArgb(28, 28, 28);

        pnlCola.BackColor = Color.FromArgb(28, 28, 28);

        pnlArbol.BackColor = Color.FromArgb(28, 28, 28);

        CargarCanciones();
    }
    
    // ESTILOS
    private void AplicarEstilos()
{
    Color fondoPrincipal = Color.FromArgb(18, 18, 18);
    Color fondoSecundario = Color.FromArgb(24, 24, 24);
    Color fondoControles = Color.FromArgb(40, 40, 40);
    Color verdeSpotify = Color.FromArgb(30, 215, 96);
    Color textoPrincipal = Color.White;
    Color textoSecundario = Color.FromArgb(179, 179, 179);
    
    // Formulario
    Text = "Music Player - Práctica 2";
    StartPosition = FormStartPosition.CenterScreen;

    BackColor = fondoPrincipal;
    ForeColor = textoPrincipal;

    Font = new Font("Segoe UI", 10);
    
    lblTitulo.ForeColor = textoPrincipal;
    lblArtista.ForeColor = textoSecundario;
    lblGenero.ForeColor = textoSecundario;
    lblDuracion.ForeColor = textoSecundario;

    lblTitulo.Font = new Font(
        "Segoe UI",
        13,
        FontStyle.Bold
    );

    lblArtista.Font = new Font(
        "Segoe UI",
        10
    );

    lblGenero.Font = new Font(
        "Segoe UI",
        10
    );

    lblDuracion.Font = new Font(
        "Segoe UI",
        10
    );

    lblTiempoTotal.ForeColor = verdeSpotify;

    lblTiempoTotal.Font = new Font(
        "Segoe UI",
        11,
        FontStyle.Bold
    );
    
    lblResultado.ForeColor = textoPrincipal;

    lblResultado.Font = new Font(
        "Segoe UI",
        10
    );

    txtBuscar.BackColor = fondoControles;
    txtBuscar.ForeColor = textoPrincipal;
    txtBuscar.BorderStyle = BorderStyle.FixedSingle;

    txtBuscar.Font = new Font(
        "Segoe UI",
        10
    );
    
    // Botones
    EstilizarBotonOscuro(btnBuscar);
    EstilizarBotonOscuro(btnVerCola);
    EstilizarBotonOscuro(btnVerArbol);
    
    btnReproducir.BackColor = verdeSpotify;
    btnReproducir.ForeColor = Color.Black;

    btnReproducir.FlatStyle = FlatStyle.Flat;
    btnReproducir.FlatAppearance.BorderSize = 0;

    btnReproducir.Font = new Font(
        "Segoe UI",
        10,
        FontStyle.Bold
    );

    btnReproducir.Cursor = Cursors.Hand;
    
    picCola.BackColor = Color.White;
    picArbol.BackColor = Color.White;

    picCola.BorderStyle = BorderStyle.None;
    picArbol.BorderStyle = BorderStyle.None;

    picCola.SizeMode = PictureBoxSizeMode.Zoom;
    picArbol.SizeMode = PictureBoxSizeMode.Zoom;
}


    private void EstilizarBotonOscuro(Button boton)
    {
        boton.BackColor = Color.FromArgb(40, 40, 40);
        boton.ForeColor = Color.White;

        boton.FlatStyle = FlatStyle.Flat;

        boton.FlatAppearance.BorderSize = 0;
        boton.FlatAppearance.MouseOverBackColor =
            Color.FromArgb(55, 55, 55);

        boton.FlatAppearance.MouseDownBackColor =
            Color.FromArgb(70, 70, 70);

        boton.Font = new Font(
            "Segoe UI",
            9,
            FontStyle.Bold
        );

        boton.Cursor = Cursors.Hand;
    }
    
    // Cargar canciones
    public void CargarCanciones()
    {
        CargadorCanciones cargador =
            new CargadorCanciones();

        string ruta =
            Path.Combine(
                AppContext.BaseDirectory,
                "Data",
                "canciones.json"
            );

        Cancion[] canciones =
            cargador.Cargar(ruta);

        if (canciones.Length == 0)
        {
            MessageBox.Show(
                "No se encontraron canciones.\n\n" +
                "Ruta utilizada:\n" +
                ruta
            );

            return;
        }

        foreach (Cancion cancion in canciones)
        {
            cola.Encolar(cancion);
            arbol.Insertar(cancion);
        }

        ActualizarTiempoTotal();
        ActualizarGraficas();
    }
    
    // Tiempo
    private void ActualizarTiempoTotal()
    {
        int tiempo =
            cola.ObtenerTiempoTotal();

        lblTiempoTotal.Text =
            "Tiempo restante: " +
            tiempo +
            " minutos";
    }
    
    // Imagenes
    private void MostrarImagen(
        PictureBox pictureBox,
        string ruta
    )
    {
        if (!File.Exists(ruta))
        {
            return;
        }

        if (pictureBox.Image != null)
        {
            pictureBox.Image.Dispose();
            pictureBox.Image = null;
        }

        using FileStream stream =
            new FileStream(
                ruta,
                FileMode.Open,
                FileAccess.Read
            );

        using Image imagenTemporal =
            Image.FromStream(stream);

        pictureBox.Image =
            new Bitmap(imagenTemporal);
    }

    private void ActualizarGraficas()
    {
        try
        {
            string rutaCola =
                graphviz.GenerarCola(
                    cola.ObtenerFrente()
                );

            string rutaArbol =
                graphviz.GenerarArbol(
                    arbol.ObtenerRaiz()
                );

            MostrarImagen(
                picCola,
                rutaCola
            );

            MostrarImagen(
                picArbol,
                rutaArbol
            );
        }
        catch
        {

        }
    }
    
    // Reproducir
    private void btnReproducir_Click(
        object sender,
        EventArgs e
    )
    {
        Cancion? cancion =
            cola.Desencolar();

        if (cancion == null)
        {
            MessageBox.Show(
                "La cola de reproducción está vacía.",
                "Cola vacía",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            return;
        }

        lblTitulo.Text =
            "Título: " +
            cancion.Titulo;

        lblArtista.Text =
            "Artista: " +
            cancion.Artista;

        lblGenero.Text =
            "Género: " +
            cancion.Genero;

        lblDuracion.Text =
            "Duración: " +
            cancion.Duracion +
            " minutos";

        ActualizarTiempoTotal();
        ActualizarGraficas();

        if (cola.EstaVacia())
        {
            btnReproducir.Enabled = false;
            btnReproducir.Text = "COLA VACÍA";
            btnReproducir.BackColor =
                Color.FromArgb(70, 70, 70);
        }
    }
    
    // Buscar
    private void btnBuscar_Click(
        object sender,
        EventArgs e
    )
    {
        string titulo =
            txtBuscar.Text.Trim();

        if (string.IsNullOrWhiteSpace(titulo))
        {
            MessageBox.Show(
                "Ingrese el título de una canción.",
                "Búsqueda",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            txtBuscar.Focus();

            return;
        }

        Cancion? cancion =
            arbol.Buscar(titulo);

        if (cancion == null)
        {
            lblResultado.ForeColor = Color.FromArgb(255, 100, 100);

            lblResultado.Text = "Canción no encontrada.";

            return;
        }

        lblResultado.ForeColor = Color.FromArgb(30, 215, 96);

        lblResultado.Text =
            "Título: " +
            cancion.Titulo +
            "\n" +

            "Artista: " +
            cancion.Artista +
            "\n" +

            "Género: " +
            cancion.Genero +
            "\n" +

            "Duración: " +
            cancion.Duracion +
            " minutos";
    }


    private void txtBuscar_KeyDown(
        object sender,
        KeyEventArgs e
    )
    {
        if (e.KeyCode == Keys.Enter)
        {
            btnBuscar.PerformClick();

            e.SuppressKeyPress = true;
        }
    }
    
    // Grapvhiz
    private void btnVerCola_Click(
        object sender,
        EventArgs e
    )
    {
        try
        {
            string ruta =
                graphviz.GenerarCola(
                    cola.ObtenerFrente()
                );

            MostrarImagen(
                picCola,
                ruta
            );
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "No se pudo generar la gráfica de la cola.\n\n" +
                ex.Message
            );
        }
    }

    private void btnVerArbol_Click(
        object sender,
        EventArgs e
    )
    {
        try
        {
            string ruta =
                graphviz.GenerarArbol(
                    arbol.ObtenerRaiz()
                );

            MostrarImagen(
                picArbol,
                ruta
            );
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "No se pudo generar la gráfica del árbol.\n\n" +
                ex.Message
            );
        }
    }
    
    
}