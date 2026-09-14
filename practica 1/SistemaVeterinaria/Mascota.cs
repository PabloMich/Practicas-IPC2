using System;

namespace SistemaVeterinaria
{

public abstract class Mascota
{
    public string Nombre {get; set;}
    public double Peso {get; set;}
    public string Sexo {get; set;}
    public int Edad {get; set;}
    public string Propietario {get; set;}
    
    public string CodigoUnico {get; private set;}
    public string Estado {get; private set;} // Enfermo o sano
    
    // Constructor
    public Mascota(string nombre, double peso, string sexo, int edad, string propietario)
    {
        Nombre = nombre;
        Peso = peso;
        Sexo = sexo;
        Edad = edad;
        Propietario = propietario;
        Estado = "enfermo"; // por defecto
        CodigoUnico = GenerarCodigoUnico();
    }

    private string GenerarCodigoUnico()
    {
        const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();
        var resultado = new char[8];

        for (int i = 0; i < 8; i++)
        {
            resultado[i] = caracteres[random.Next(caracteres.Length)];
        }
        return new string(resultado);
    }
    
    public abstract double CalcularDosis(double dosisPorKg);

    public void CambiarEstado(string nuevoEstado)
    {
        Estado = nuevoEstado.ToLower();
    }

    public virtual void MostrarInformacion()
    {
        Console.WriteLine($"\n--- Paciente: {Nombre} [{CodigoUnico}] ---");
        Console.WriteLine($"Especie: {this.GetType().Name}");
        Console.WriteLine($"Propietario: {this.Propietario}");
        Console.WriteLine($"Peso: {Peso}kg | Edad: {Edad}años | Sexo: {Sexo}");
        Console.WriteLine($"Estado: {Estado.ToUpper()}");
    }
}
}