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
        SuspendLayout();
        // 
        // lblTitulo
        // 
        lblTitulo.Location = new System.Drawing.Point(36, 24);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new System.Drawing.Size(406, 26);
        lblTitulo.TabIndex = 0;
        lblTitulo.Click += label1_Click;
        // 
        // lblArtista
        // 
        lblArtista.Location = new System.Drawing.Point(36, 62);
        lblArtista.Name = "lblArtista";
        lblArtista.Size = new System.Drawing.Size(406, 23);
        lblArtista.TabIndex = 1;
        // 
        // lblGenero
        // 
        lblGenero.Location = new System.Drawing.Point(36, 100);
        lblGenero.Name = "lblGenero";
        lblGenero.Size = new System.Drawing.Size(406, 23);
        lblGenero.TabIndex = 2;
        // 
        // lblDuracion
        // 
        lblDuracion.Location = new System.Drawing.Point(36, 144);
        lblDuracion.Name = "lblDuracion";
        lblDuracion.Size = new System.Drawing.Size(406, 23);
        lblDuracion.TabIndex = 3;
        // 
        // btnReproducir
        // 
        btnReproducir.Location = new System.Drawing.Point(191, 181);
        btnReproducir.Name = "btnReproducir";
        btnReproducir.Size = new System.Drawing.Size(120, 35);
        btnReproducir.TabIndex = 4;
        btnReproducir.Text = "REPRODUCIR";
        btnReproducir.UseVisualStyleBackColor = true;
        btnReproducir.Click += btnReproducir_Click;
        // 
        // txtBuscar
        // 
        txtBuscar.Location = new System.Drawing.Point(36, 303);
        txtBuscar.Name = "txtBuscar";
        txtBuscar.Size = new System.Drawing.Size(250, 27);
        txtBuscar.TabIndex = 5;
        // 
        // btnBuscar
        // 
        btnBuscar.Location = new System.Drawing.Point(306, 297);
        btnBuscar.Name = "btnBuscar";
        btnBuscar.Size = new System.Drawing.Size(136, 33);
        btnBuscar.TabIndex = 6;
        btnBuscar.Text = "BUSCAR";
        btnBuscar.UseVisualStyleBackColor = true;
        btnBuscar.Click += btnBuscar_Click;
        // 
        // lblResultado
        // 
        lblResultado.Location = new System.Drawing.Point(33, 364);
        lblResultado.Name = "lblResultado";
        lblResultado.Size = new System.Drawing.Size(456, 107);
        lblResultado.TabIndex = 7;
        // 
        // lblTiempoTotal
        // 
        lblTiempoTotal.Location = new System.Drawing.Point(33, 485);
        lblTiempoTotal.Name = "lblTiempoTotal";
        lblTiempoTotal.Size = new System.Drawing.Size(451, 92);
        lblTiempoTotal.TabIndex = 8;
        // 
        // FrmPrincipal
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(507, 620);
        Controls.Add(lblTiempoTotal);
        Controls.Add(lblResultado);
        Controls.Add(btnBuscar);
        Controls.Add(txtBuscar);
        Controls.Add(btnReproducir);
        Controls.Add(lblDuracion);
        Controls.Add(lblGenero);
        Controls.Add(lblArtista);
        Controls.Add(lblTitulo);
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

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