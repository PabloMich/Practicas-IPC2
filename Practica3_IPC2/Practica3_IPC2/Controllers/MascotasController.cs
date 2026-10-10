using Microsoft.AspNetCore.Mvc;
using Practica3_IPC2.Estructuras;
using Practica3_IPC2.Models;

namespace Practica3_IPC2.Controllers
{
    public class MascotasController : Controller
    {
        private readonly ListaMascotas veterinaria;
        
        public MascotasController(ListaMascotas listaMascotas)
        {
            veterinaria = listaMascotas;
        }
        
        // Listar mascotas
        [HttpGet]
        public IActionResult Index()
        {
            return View(veterinaria);
        }
        
        // Registar mascota
        [HttpGet]
        public IActionResult Crear()
        {
            return View(new MascotaFormulario());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(MascotaFormulario formulario)
        {
            ValidarEspecie(formulario);

            if (!ModelState.IsValid)
            {
                return View(formulario);
            }

            Mascota? nuevaMascota = CrearObjetoMascota(formulario);

            if (nuevaMascota == null)
            {
                ModelState.AddModelError("Tipo", "Especie inválida.");
                return View(formulario);
            }

            veterinaria.Agregar(nuevaMascota);

            TempData["Mensaje"] = "Mascota registrada correctamente.";

            return RedirectToAction(nameof(Index));
        }
        
        // Consultar info
        [HttpGet]
        public IActionResult Detalles(string codigo)
        {
            Mascota? mascota = veterinaria.Buscar(codigo);

            if (mascota == null)
            {
                return NotFound();
            }

            return View(mascota);
        }
        
        // Editar mascota
        [HttpGet]
        public IActionResult Editar(string codigo)
        {
            Mascota? mascota = veterinaria.Buscar(codigo);

            if (mascota == null)
            {
                return NotFound();
            }

            MascotaFormulario formulario = ConvertirAFormulario(mascota);

            ViewBag.Codigo = mascota.CodigoUnico;

            return View(formulario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(string codigo, MascotaFormulario formulario)
        {
            Mascota? mascota = veterinaria.Buscar(codigo);

            if (mascota == null)
            {
                return NotFound();
            }

            // La especie original no se cambia al editar
            formulario.Tipo = mascota.GetType().Name;
            ModelState.Remove(nameof(formulario.Tipo));

            ValidarEspecie(formulario);

            if (!ModelState.IsValid)
            {
                ViewBag.Codigo = codigo;
                return View(formulario);
            }

            // Actualizar datos generales
            mascota.Nombre = formulario.Nombre;
            mascota.Peso = formulario.Peso;
            mascota.Sexo = formulario.Sexo;
            mascota.Edad = formulario.Edad;
            mascota.Propietario = formulario.Propietario;

            // Actualizar datos propios de cada especie
            if (mascota is Perro perro)
            {
                perro.Raza = formulario.Raza;
                perro.Tamano = formulario.Tamano;
            }
            else if (mascota is Gato gato)
            {
                gato.Raza = formulario.Raza;
                gato.IsEsterilizado = formulario.IsEsterilizado;
            }
            else if (mascota is Ave ave)
            {
                ave.EnvergaduraAlas = formulario.EnvergaduraAlas;
                ave.PuedeVolar = formulario.PuedeVolar;
            }
            else if (mascota is Tortuga tortuga)
            {
                tortuga.TipoCaparazon = formulario.TipoCaparazon;
                tortuga.EsAcuatica = formulario.EsAcuatica;
            }

            TempData["Mensaje"] = "Información actualizada correctamente.";

            return RedirectToAction(nameof(Index));
        }
        
        // Eliminar mascota
        [HttpGet]
        public IActionResult Eliminar(string codigo)
        {
            Mascota? mascota = veterinaria.Buscar(codigo);

            if (mascota == null)
            {
                return NotFound();
            }

            return View(mascota);
        }

        [HttpPost]
        [ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmarEliminar(string codigo)
        {
            bool eliminado = veterinaria.Eliminar(codigo);

            if (!eliminado)
            {
                return NotFound();
            }

            TempData["Mensaje"] = "Mascota eliminada correctamente.";

            return RedirectToAction(nameof(Index));
        }
        
        //Cambiar estado
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CambiarEstado(string codigo)
        {
            Mascota? mascota = veterinaria.Buscar(codigo);

            if (mascota == null)
            {
                return NotFound();
            }

            string nuevoEstado = mascota.Estado == "sano"
                ? "enfermo"
                : "sano";

            mascota.CambiarEstado(nuevoEstado);

            TempData["Mensaje"] = "Estado actualizado correctamente.";

            return RedirectToAction(nameof(Index));
        }
        
        // Calcular dosis
        [HttpGet]
        public IActionResult Dosis(string codigo)
        {
            Mascota? mascota = veterinaria.Buscar(codigo);

            if (mascota == null)
            {
                return NotFound();
            }

            return View(mascota);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Dosis(string codigo, double dosisPorKg)
        {
            Mascota? mascota = veterinaria.Buscar(codigo);

            if (mascota == null)
            {
                return NotFound();
            }

            if (double.IsNaN(dosisPorKg) ||
                double.IsInfinity(dosisPorKg) ||
                dosisPorKg <= 0)
            {
                ViewBag.Error = "Ingrese una dosis válida mayor que cero.";
                return View(mascota);
            }
            
            double resultado = mascota.CalcularDosis(dosisPorKg);

            ViewBag.DosisPorKg = dosisPorKg;
            ViewBag.Resultado = resultado;

            return View(mascota);
        }
        
        // Métodos auxiliares
        
        // Validar los campos particulares de la especie
        private void ValidarEspecie(MascotaFormulario f)
        {
            switch (f.Tipo)
            {
                case "Perro":
                    if (string.IsNullOrWhiteSpace(f.Raza))
                        ModelState.AddModelError("Raza", "Ingrese la raza.");

                    if (string.IsNullOrWhiteSpace(f.Tamano))
                        ModelState.AddModelError("Tamano", "Ingrese el tamaño.");
                    break;

                case "Gato":
                    if (string.IsNullOrWhiteSpace(f.Raza))
                        ModelState.AddModelError("Raza", "Ingrese la raza.");
                    break;

                case "Ave":
                    if (f.EnvergaduraAlas <= 0 ||
                        double.IsNaN(f.EnvergaduraAlas) ||
                        double.IsInfinity(f.EnvergaduraAlas))
                        ModelState.AddModelError(
                            "EnvergaduraAlas",
                            "Ingrese una envergadura válida.");
                    break;

                case "Tortuga":
                    if (string.IsNullOrWhiteSpace(f.TipoCaparazon))
                        ModelState.AddModelError(
                            "TipoCaparazon",
                            "Ingrese el tipo de caparazón.");
                    break;

                default:
                    ModelState.AddModelError("Tipo", "Seleccione una especie válida.");
                    break;
            }
        }

        // Crear la especie correspondiente
        private Mascota? CrearObjetoMascota(MascotaFormulario f)
        {
            switch (f.Tipo)
            {
                case "Perro":
                    return new Perro(
                        f.Nombre, f.Peso, f.Sexo, f.Edad,
                        f.Propietario, f.Raza, f.Tamano);

                case "Gato":
                    return new Gato(
                        f.Nombre, f.Peso, f.Sexo, f.Edad,
                        f.Propietario, f.Raza, f.IsEsterilizado);

                case "Ave":
                    return new Ave(
                        f.Nombre, f.Peso, f.Sexo, f.Edad,
                        f.Propietario, f.EnvergaduraAlas, f.PuedeVolar);

                case "Tortuga":
                    return new Tortuga(
                        f.Nombre, f.Peso, f.Sexo, f.Edad,
                        f.Propietario, f.TipoCaparazon, f.EsAcuatica);

                default:
                    return null;
            }
        }
        
        private MascotaFormulario ConvertirAFormulario(Mascota mascota)
        {
            MascotaFormulario f = new MascotaFormulario
            {
                Nombre = mascota.Nombre,
                Peso = mascota.Peso,
                Sexo = mascota.Sexo,
                Edad = mascota.Edad,
                Propietario = mascota.Propietario,
                Tipo = mascota.GetType().Name
            };

            if (mascota is Perro perro)
            {
                f.Raza = perro.Raza;
                f.Tamano = perro.Tamano;
            }
            else if (mascota is Gato gato)
            {
                f.Raza = gato.Raza;
                f.IsEsterilizado = gato.IsEsterilizado;
            }
            else if (mascota is Ave ave)
            {
                f.EnvergaduraAlas = ave.EnvergaduraAlas;
                f.PuedeVolar = ave.PuedeVolar;
            }
            else if (mascota is Tortuga tortuga)
            {
                f.TipoCaparazon = tortuga.TipoCaparazon;
                f.EsAcuatica = tortuga.EsAcuatica;
            }

            return f;
        }
    }
}
