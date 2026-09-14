namespace SistemaVeterinaria
{
    public class Gato : Mascota
    {
        public string Raza { get; set; }
        public bool IsEsterilizado { get; set; }

        public Gato(string nombre, double peso, string sexo, int edad, string propietario, string raza,
            bool isEsterilizado)
            : base(nombre, peso, sexo, edad, propietario)
        {
            Raza = raza;
            IsEsterilizado = isEsterilizado;
        }

        public override double CalcularDosis(double dosisPorKg)
        {
            return (Peso * dosisPorKg) * 0.90;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Raza: {Raza} | Esterilizado: {(IsEsterilizado ? "Si" : "No")}");
        }
    }
}