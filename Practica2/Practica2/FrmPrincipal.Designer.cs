namespace Practica2;

partial class FrmPrincipal
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        lblTitulo = new System.Windows.Forms.Label();
        lblArtista = new System.Windows.Forms.Label();
        lblGenero = new System.Windows.Forms.Label();
        lblDuracion = new System.Windows.Forms.Label();
        btnReproducir = new System.Windows.Forms.Button();
        txtBuscar = new System.Windows.Forms.TextBox();
        btnBuscar = new System.Windows.Forms.Button();
        lblResultado = new System.Windows.Forms.Label();
        lblTiempoTotal = new System.Windows.Forms.Label();
        btnVerCola = new System.Windows.Forms.Button();
        btnVerArbol = new System.Windows.Forms.Button();
        picCola = new System.Windows.Forms.PictureBox();
        picArbol = new System.Windows.Forms.PictureBox();
        pnlCancionActual = new System.Windows.Forms.Panel();
        pnlCola = new System.Windows.Forms.Panel();
        pnlArbol = new System.Windows.Forms.Panel();
        ((System.ComponentModel.ISupportInitialize)picCola).BeginInit();
        ((System.ComponentModel.ISupportInitialize)picArbol).BeginInit();
        pnlCancionActual.SuspendLayout();
        pnlCola.SuspendLayout();
        pnlArbol.SuspendLayout();
        SuspendLayout();
        // 
        // lblTitulo
        // 
        lblTitulo.Location = new System.Drawing.Point(12, 19);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new System.Drawing.Size(325, 26);
        lblTitulo.TabIndex = 0;
        // 
        // lblArtista
        // 
        lblArtista.Location = new System.Drawing.Point(18, 58);
        lblArtista.Name = "lblArtista";
        lblArtista.Size = new System.Drawing.Size(319, 23);
        lblArtista.TabIndex = 1;
        // 
        // lblGenero
        // 
        lblGenero.Location = new System.Drawing.Point(18, 91);
        lblGenero.Name = "lblGenero";
        lblGenero.Size = new System.Drawing.Size(319, 23);
        lblGenero.TabIndex = 2;
        // 
        // lblDuracion
        // 
        lblDuracion.Location = new System.Drawing.Point(12, 121);
        lblDuracion.Name = "lblDuracion";
        lblDuracion.Size = new System.Drawing.Size(325, 23);
        lblDuracion.TabIndex = 3;
        // 
        // btnReproducir
        // 
        btnReproducir.Location = new System.Drawing.Point(187, 255);
        btnReproducir.Name = "btnReproducir";
        btnReproducir.Size = new System.Drawing.Size(181, 35);
        btnReproducir.TabIndex = 4;
        btnReproducir.Text = "REPRODUCIR";
        btnReproducir.UseVisualStyleBackColor = true;
        btnReproducir.Click += btnReproducir_Click;
        // 
        // txtBuscar
        // 
        txtBuscar.Location = new System.Drawing.Point(15, 364);
        txtBuscar.Name = "txtBuscar";
        txtBuscar.Size = new System.Drawing.Size(262, 27);
        txtBuscar.TabIndex = 5;
        // 
        // btnBuscar
        // 
        btnBuscar.Location = new System.Drawing.Point(303, 361);
        btnBuscar.Name = "btnBuscar";
        btnBuscar.Size = new System.Drawing.Size(96, 33);
        btnBuscar.TabIndex = 6;
        btnBuscar.Text = "BUSCAR";
        btnBuscar.UseVisualStyleBackColor = true;
        btnBuscar.Click += btnBuscar_Click;
        // 
        // lblResultado
        // 
        lblResultado.Location = new System.Drawing.Point(15, 439);
        lblResultado.Name = "lblResultado";
        lblResultado.Size = new System.Drawing.Size(387, 122);
        lblResultado.TabIndex = 7;
        // 
        // lblTiempoTotal
        // 
        lblTiempoTotal.Location = new System.Drawing.Point(15, 576);
        lblTiempoTotal.Name = "lblTiempoTotal";
        lblTiempoTotal.Size = new System.Drawing.Size(387, 127);
        lblTiempoTotal.TabIndex = 8;
        // 
        // btnVerCola
        // 
        btnVerCola.Location = new System.Drawing.Point(569, 24);
        btnVerCola.Name = "btnVerCola";
        btnVerCola.Size = new System.Drawing.Size(142, 34);
        btnVerCola.TabIndex = 9;
        btnVerCola.Text = "VER COLA";
        btnVerCola.UseVisualStyleBackColor = true;
        btnVerCola.Click += btnVerCola_Click;
        // 
        // btnVerArbol
        // 
        btnVerArbol.Location = new System.Drawing.Point(775, 24);
        btnVerArbol.Name = "btnVerArbol";
        btnVerArbol.Size = new System.Drawing.Size(152, 34);
        btnVerArbol.TabIndex = 10;
        btnVerArbol.Text = "VER ÁRBOL";
        btnVerArbol.UseVisualStyleBackColor = true;
        btnVerArbol.Click += btnVerArbol_Click;
        // 
        // picCola
        // 
        picCola.Location = new System.Drawing.Point(8, 7);
        picCola.Name = "picCola";
        picCola.Size = new System.Drawing.Size(576, 284);
        picCola.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        picCola.TabIndex = 11;
        picCola.TabStop = false;
        // 
        // picArbol
        // 
        picArbol.Location = new System.Drawing.Point(5, 2);
        picArbol.Name = "picArbol";
        picArbol.Size = new System.Drawing.Size(576, 309);
        picArbol.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        picArbol.TabIndex = 12;
        picArbol.TabStop = false;
        // 
        // pnlCancionActual
        // 
        pnlCancionActual.Controls.Add(btnReproducir);
        pnlCancionActual.Controls.Add(lblArtista);
        pnlCancionActual.Controls.Add(lblGenero);
        pnlCancionActual.Controls.Add(lblTitulo);
        pnlCancionActual.Controls.Add(lblDuracion);
        pnlCancionActual.Location = new System.Drawing.Point(15, 24);
        pnlCancionActual.Name = "pnlCancionActual";
        pnlCancionActual.Size = new System.Drawing.Size(387, 317);
        pnlCancionActual.TabIndex = 13;
        // 
        // pnlCola
        // 
        pnlCola.Controls.Add(picCola);
        pnlCola.Location = new System.Drawing.Point(431, 82);
        pnlCola.Name = "pnlCola";
        pnlCola.Size = new System.Drawing.Size(594, 299);
        pnlCola.TabIndex = 14;
        // 
        // pnlArbol
        // 
        pnlArbol.Controls.Add(picArbol);
        pnlArbol.Location = new System.Drawing.Point(434, 392);
        pnlArbol.Name = "pnlArbol";
        pnlArbol.Size = new System.Drawing.Size(590, 322);
        pnlArbol.TabIndex = 15;
        // 
        // FrmPrincipal
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1043, 731);
        Controls.Add(pnlArbol);
        Controls.Add(pnlCola);
        Controls.Add(pnlCancionActual);
        Controls.Add(btnVerArbol);
        Controls.Add(btnVerCola);
        Controls.Add(lblTiempoTotal);
        Controls.Add(lblResultado);
        Controls.Add(btnBuscar);
        Controls.Add(txtBuscar);
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Reproductor de Música";
        ((System.ComponentModel.ISupportInitialize)picCola).EndInit();
        ((System.ComponentModel.ISupportInitialize)picArbol).EndInit();
        pnlCancionActual.ResumeLayout(false);
        pnlCola.ResumeLayout(false);
        pnlArbol.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Panel pnlCancionActual;
    private System.Windows.Forms.Panel pnlCola;
    private System.Windows.Forms.Panel pnlArbol;

    private System.Windows.Forms.Button btnVerCola;
    private System.Windows.Forms.Button btnVerArbol;
    private System.Windows.Forms.PictureBox picCola;
    private System.Windows.Forms.PictureBox picArbol;

    private System.Windows.Forms.Button btnReproducir;
    private System.Windows.Forms.TextBox txtBuscar;
    private System.Windows.Forms.Button btnBuscar;
    private System.Windows.Forms.Label lblResultado;
    private System.Windows.Forms.Label lblTiempoTotal;

    private System.Windows.Forms.Label lblTitulo;
    private System.Windows.Forms.Label lblArtista;
    private System.Windows.Forms.Label lblGenero;
    private System.Windows.Forms.Label lblDuracion;

    #endregion
}