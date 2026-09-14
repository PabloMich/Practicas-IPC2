using System;
using System.Collections.Generic;

namespace SistemaVeterinaria
{
    class Program
    {
        static List<Mascota> veterinaria = new List<Mascota>();

        static void Main(string[] args)
        {
            bool continuar = true;
            
            while (continuar)
            {
                Console.WriteLine("\n========================================");
                Console.WriteLine("    VETERINARIA - CONTROL DE CITAS");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Registrar nueva mascota");
                Console.WriteLine("2. Gestionar pacientes (Cambiar estado, dosis, etc.)");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");
                
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        MenuRegistrarMascota();
                        break;
                    case "2":
                        MenuGestionarPacientes();
                        break;
                    case "3":
                        Console.WriteLine("\nGracias por utilizar el sistema");
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("\nOpción inválida, intente de nuevo.");
                        break;
                }
            }
        }
        
        // SUB-MENÚ 1: REGISTRAR MASCOTAS
        static void MenuRegistrarMascota()
        {
            Console.WriteLine("\n--- Seleccione la Especie ---");
            Console.WriteLine("1. Perro");
            Console.WriteLine("2. Gato");
            Console.WriteLine("3. Ave");
            Console.WriteLine("4. Tortuga");
            Console.Write("Especie: ");
            string tipo = Console.ReadLine();

            if (tipo != "1" && tipo != "2" && tipo != "3" && tipo != "4")
            {
                Console.WriteLine("Tipo de mascota inválido.");
                return;
            }
            
            Console.Write("Nombre de la mascota: ");
            string nombre = Console.ReadLine();
            Console.Write("Peso (en kg): ");
            double peso = Convert.ToDouble(Console.ReadLine());
            Console.Write("Sexo: ");
            string sexo = Console.ReadLine();
            Console.Write("Edad: ");
            int edad = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nombre del Propietario: ");
            string propietario = Console.ReadLine();
            
            if (tipo == "1") // Perro
            {
                Console.Write("Raza: ");
                string raza = Console.ReadLine();
                Console.Write("Tamaño (Pequeño, Mediano, Grande): ");
                string tamano = Console.ReadLine();
                
                Perro nuevoPerro = new Perro(nombre, peso, sexo, edad, propietario, raza, tamano);
                veterinaria.Add(nuevoPerro);
                Console.WriteLine($"\nPerro registrado. Código único asignado: {nuevoPerro.CodigoUnico}");
            }
            else if (tipo == "2") // Gato
            {
                Console.Write("Raza: ");
                string raza = Console.ReadLine();
                Console.Write("¿Está esterilizado? (s/n): ");
                bool esterilizado = Console.ReadLine().ToLower() == "s";

                Gato nuevoGato = new Gato(nombre, peso, sexo, edad, propietario, raza, esterilizado);
                veterinaria.Add(nuevoGato);
                Console.WriteLine($"\nGato registrado. Código único asignado: {nuevoGato.CodigoUnico}");
            }
            else if (tipo == "3") // Ave
            {
                Console.Write("Envergadura de alas (en cm): ");
                double envergadura = Convert.ToDouble(Console.ReadLine());
                Console.Write("¿Puede volar? (s/n): ");
                bool vuela = Console.ReadLine().ToLower() == "s";

                Ave nuevaAve = new Ave(nombre, peso, sexo, edad, propietario, envergadura, vuela);
                veterinaria.Add(nuevaAve);
                Console.WriteLine($"\nAve registrada. Código único asignado: {nuevaAve.CodigoUnico}");
            }
            else if (tipo == "4") // Tortuga
            {
                Console.Write("Tipo de caparazón: ");
                string caparazon = Console.ReadLine();
                Console.Write("¿Es acuática? (s/n): ");
                bool acuatico = Console.ReadLine().ToLower() == "s";

                Tortuga nuevaTortuga = new Tortuga(nombre, peso, sexo, edad, propietario, caparazon, acuatico);
                veterinaria.Add(nuevaTortuga);
                Console.WriteLine($"\nTortuga registrada. Código único asignado: {nuevaTortuga.CodigoUnico}");
            }
        }
        
        // SUB-MENÚ 2: GESTIONAR PACIENTES YA REGISTRADOS
        static void MenuGestionarPacientes()
        {
            if (veterinaria.Count == 0)
            {
                Console.WriteLine("\nNo hay mascotas registradas.");
                return;
            }

            Console.Write("\nIngrese el Código Único de 8 caracteres del paciente: ");
            string codigoBuscar = Console.ReadLine().ToUpper();
            
            Mascota pacienteEncontrado = null;
            foreach (var m in veterinaria)
            {
                if (m.CodigoUnico == codigoBuscar)
                {
                    pacienteEncontrado = m;
                    break;
                }
            }

            if (pacienteEncontrado == null)
            {
                Console.WriteLine("Paciente no encontrado con ese código.");
                return;
            }
            
            Console.WriteLine($"\n--- Gestionando a: {pacienteEncontrado.Nombre} ---");
            Console.WriteLine("1. Mostrar información general");
            Console.WriteLine("2. Cambiar estado (Sano / Enfermo)");
            Console.WriteLine("3. Calcular dosis de medicamento");
            Console.Write("Seleccione acción: ");
            string accion = Console.ReadLine();

            if (accion == "1")
            {
                pacienteEncontrado.MostrarInformacion();
            }
            else if (accion == "2")
            {
                Console.Write("Ingrese el nuevo estado (Sano / Enfermo): ");
                string estadoNuevo = Console.ReadLine();
                pacienteEncontrado.CambiarEstado(estadoNuevo);
                Console.WriteLine($"\nEstado de {pacienteEncontrado.Nombre} actualizado a: {estadoNuevo.ToUpper()}");
            }
            else if (accion == "3")
            {
                Console.Write("Ingrese la dosis estándar por kilogramo (mg/kg): ");
                double dosisKg = Convert.ToDouble(Console.ReadLine());
                
                double dosisFinal = pacienteEncontrado.CalcularDosis(dosisKg);
                Console.WriteLine($"\nSe le deben administrar {dosisFinal} mg de medicamento.");
            }
            else
            {
                Console.WriteLine("[Error] Opción inválida.");
            }
        }
    }
}