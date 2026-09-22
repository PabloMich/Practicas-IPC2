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
    
    private float zoomCola = 1.0f;
    private float zoomArbol = 1.0f;

    private string? rutaImagenColaActual;
    private string? rutaImagenArbolActual;

    public FrmPrincipal()
    {
        InitializeComponent();

        AplicarEstilos();
        
        cola = new ColaReproduccion();
        arbol = new ArbolBinario();
        graphviz = new GraphvizService();
        
        lblTitulo.Text = "Ninguna canción";
        lblArtista.Text = "Carga un archivo JSON para comenzar";
        lblGenero.Text = "";
        lblDuracion.Text = "";
        
        txtBuscar.Clear();
        lblResultado.Text = "";
        btnBuscar.Enabled = false;
        txtBuscar.Enabled = false;
        
        ActualizarTiempoTotal();
        
        btnReproducir.Enabled = false;
        btnReproducir.Text = "▶ REPRODUCIR";
        
        ActualizarGraficas();
    }
    
    private void MostrarImagenConZoom(
        PictureBox pictureBox,
        string ruta,
        float zoom
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

        using FileStream stream = new FileStream(
            ruta,
            FileMode.Open,
            FileAccess.Read
        );

        using Image imagenTemporal =
            Image.FromStream(stream);

        int nuevoAncho = (int)(imagenTemporal.Width * zoom);
        int nuevoAlto = (int)(imagenTemporal.Height * zoom);

        Bitmap imagenEscalada = new Bitmap(
            imagenTemporal,
            new Size(nuevoAncho, nuevoAlto)
        );

        pictureBox.Image = imagenEscalada;
        
        pictureBox.Size = new Size(
            nuevoAncho,
            nuevoAlto
        );
    }
    
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
    EstilizarBotonOscuro(btnCargarJson);
    EstilizarBotonZoom(btnZoomMasCola, "+");
    EstilizarBotonZoom(btnZoomMenosCola, "−");
    EstilizarBotonZoom(btnZoomMasArbol, "+");
    EstilizarBotonZoom(btnZoomMenosArbol, "−");
    
    btnReproducir.BackColor = verdeSpotify;
    btnReproducir.ForeColor = Color.Black;

    btnReproducir.FlatStyle = FlatStyle.Flat;
    btnReproducir.FlatAppearance.BorderSize = 0;
    
    btnCargarJson.BackColor = Color.FromArgb(30, 215, 96);
    btnCargarJson.ForeColor = Color.Black;
    btnCargarJson.Text = " CARGAR JSON";

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
    public void CargarCanciones(string ruta)
{
    CargadorCanciones cargador = new CargadorCanciones();

    try
    {
        // Leer las canciones del archivo seleccionado
        Cancion[] canciones = cargador.Cargar(ruta);

        // Verificar si el archivo contiene canciones
        if (canciones.Length == 0)
        {
            MessageBox.Show(
                "El archivo JSON no contiene canciones.",
                "Archivo vacío",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            return;
        }

        // Verificar que todas las canciones tengan datos válidos
        foreach (Cancion cancion in canciones)
        {
            if (cancion == null ||
                string.IsNullOrWhiteSpace(cancion.Titulo) ||
                string.IsNullOrWhiteSpace(cancion.Artista) ||
                string.IsNullOrWhiteSpace(cancion.Genero) ||
                cancion.Duracion <= 0)
            {
                MessageBox.Show(
                    "El archivo contiene canciones con datos inválidos.\n" +
                    "Verifica título, artista, género y duración.",
                    "Error en JSON",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }
        }

        // Crear estructuras nuevas
        cola = new ColaReproduccion();
        arbol = new ArbolBinario();
        
        foreach (Cancion cancion in canciones)
        {
            cola.Encolar(cancion);
            arbol.Insertar(cancion);
        }
        
        lblTitulo.Text = "Ninguna canción";
        lblArtista.Text = "Selecciona Reproducir para comenzar";
        lblGenero.Text = "";
        lblDuracion.Text = "";

        txtBuscar.Clear();
        lblResultado.Text = "";
        
        btnReproducir.Enabled = true;
        btnReproducir.Text = "▶ REPRODUCIR";
        btnReproducir.BackColor = Color.FromArgb(30, 215, 96);
        
        ActualizarTiempoTotal();
        ActualizarGraficas();
        
        btnBuscar.Enabled = true;
        txtBuscar.Enabled = true;

        MessageBox.Show(
            "Canciones cargadas correctamente.\n\n" +
            "Cantidad: " + canciones.Length + "\n" +
            "Tiempo total: " + cola.ObtenerTiempoTotal() + " minutos.",
            "Carga completada",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        );
    }
    catch (Exception ex)
    {
        MessageBox.Show(
            "No se pudo cargar el archivo JSON.\n\n" +
            ex.Message,
            "Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
        );
    }
}
    
    private void ActualizarTiempoTotal()
    {
        int tiempo =
            cola.ObtenerTiempoTotal();

        lblTiempoTotal.Text =
            "Tiempo restante: " +
            tiempo +
            " minutos";
    }
    
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
            rutaImagenColaActual =
                graphviz.GenerarCola(
                    cola.ObtenerFrente()
                );

            rutaImagenArbolActual =
                graphviz.GenerarArbol(
                    arbol.ObtenerRaiz()
                );

            MostrarImagenConZoom(
                picCola,
                rutaImagenColaActual,
                zoomCola
            );

            MostrarImagenConZoom(
                picArbol,
                rutaImagenArbolActual,
                zoomArbol
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
            rutaImagenColaActual =
                graphviz.GenerarCola(
                    cola.ObtenerFrente()
                );

            MostrarImagenConZoom(
                picCola,
                rutaImagenColaActual,
                zoomCola
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
            rutaImagenArbolActual =
                graphviz.GenerarArbol(
                    arbol.ObtenerRaiz()
                );

            MostrarImagenConZoom(
                picArbol,
                rutaImagenArbolActual,
                zoomArbol
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


    private void btnCargarJson_Click(object sender, EventArgs e)
    {
        using OpenFileDialog explorador = new OpenFileDialog();

        explorador.Title = "Seleccionar archivo de canciones";

        explorador.Filter = "Archivos JSON (*.json)|*.json";

        explorador.FilterIndex = 1;
        explorador.Multiselect = false;
        explorador.CheckFileExists = true;

        if (explorador.ShowDialog() == DialogResult.OK)
        {
            string rutaSeleccionada = explorador.FileName;

            CargarCanciones(rutaSeleccionada);
        }
    }
    

    private void btnZoomMasCola_Click_1(object sender, EventArgs e)
    {
        if (rutaImagenColaActual == null)
        {
            return;
        }

        zoomCola += 0.2f;

        MostrarImagenConZoom(
            picCola,
            rutaImagenColaActual,
            zoomCola
        );
    }

    private void btnZoomMenosCola_Click(object sender, EventArgs e)
    {
        if (rutaImagenColaActual == null)
        {
            return;
        }

        if (zoomCola > 0.4f)
        {
            zoomCola -= 0.2f;
        }

        MostrarImagenConZoom(
            picCola,
            rutaImagenColaActual,
            zoomCola
        );
    }

    private void btnZoomMasArbol_Click(object sender, EventArgs e)
    {
        if (rutaImagenArbolActual == null)
        {
            return;
        }

        zoomArbol += 0.2f;

        MostrarImagenConZoom(
            picArbol,
            rutaImagenArbolActual,
            zoomArbol
        );
    }

    private void btnZoomMenosArbol_Click(object sender, EventArgs e)
    {
        if (rutaImagenArbolActual == null)
        {
            return;
        }

        if (zoomArbol > 0.4f)
        {
            zoomArbol -= 0.2f;
        }

        MostrarImagenConZoom(
            picArbol,
            rutaImagenArbolActual,
            zoomArbol
        );
    }
    
    private void EstilizarBotonZoom(Button boton, string signo)
    {
        boton.BackColor = Color.FromArgb(40, 40, 40);
        
        boton.ForeColor = Color.FromArgb(30, 215, 96);
        
        boton.Text = signo;
        
        boton.Font = new Font(
            "Segoe UI",
            16,
            FontStyle.Bold
        );
        
        boton.FlatStyle = FlatStyle.Flat;
        boton.FlatAppearance.BorderSize = 0;
        
        boton.FlatAppearance.MouseOverBackColor =
            Color.FromArgb(55, 55, 55);

        boton.Cursor = Cursors.Hand;
        
        boton.UseVisualStyleBackColor = false;
    }
}