using System.ComponentModel.DataAnnotations;

namespace Practica3_IPC2.Models
{
    public class MascotaFormulario
    {
        // Datos generales de cualquier mascota
        [Required(ErrorMessage = "Ingrese el nombre.")]
        public string Nombre { get; set; } = "";

        [Range(0.001, 100000, ErrorMessage = "Ingrese un peso mayor que cero.")]
        public double Peso { get; set; }

        [Required(ErrorMessage = "Seleccione el sexo.")]
        public string Sexo { get; set; } = "";

        [Range(0, 300, ErrorMessage = "Ingrese una edad válida.")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "Ingrese el propietario.")]
        public string Propietario { get; set; } = "";

        [Required(ErrorMessage = "Seleccione la especie.")]
        public string Tipo { get; set; } = "";

        // Datos de perros y gatos
        public string Raza { get; set; } = "";
        public string Tamano { get; set; } = "";
        public bool IsEsterilizado { get; set; }

        // Datos de aves
        public double EnvergaduraAlas { get; set; }
        public bool PuedeVolar { get; set; }

        // Datos de tortugas
        public string TipoCaparazon { get; set; } = "";
        public bool EsAcuatica { get; set; }
    }
}