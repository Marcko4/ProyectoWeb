using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProyectoWeb.Models;
using System.Collections.Generic;

namespace ProyectoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Variable estática para contar el número de clientes registrados
        private static int contadorCliente = 1;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Vista principal
        public IActionResult Index()
        {
            return View();
        }

        // Vista de privacidad
        public IActionResult Privacy()
        {
            return View();
        }

        // Página de error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Vista de inicio (si la usás)
        public IActionResult Inicio()
        {
            return View();
        }

        // Vista de login
        [HttpGet]
        public IActionResult Login()
        {
            return View(); // Buscará Views/Home/Login.cshtml
        }

        // Vista de registro
        [HttpGet]
        public IActionResult Registro()
        {
            return View(); // Buscará Views/Home/Registro.cshtml
        }

        // Recibe los datos del formulario de registro y genera un número de cliente
        [HttpPost]
        public IActionResult Guardar(string fullName, string cedula, string email, string phone, string address)
        {
            // Generación del número de cliente
            string numeroCliente = $"CL-{contadorCliente.ToString("D4")}";
            contadorCliente++; // Aumenta el contador para el siguiente cliente

            // Guardar los datos temporalmente
            TempData["Mensaje"] = $"¡Registro exitoso! Tu número de cliente es {numeroCliente}.";

            // Si necesitas guardar estos datos en una base de datos, este es el lugar adecuado
            // Por ejemplo:
            // _context.Clientes.Add(new Cliente { Nombre = fullName, Cedula = cedula, Email = email, Teléfono = phone, Dirección = address, NumeroCliente = numeroCliente });
            // _context.SaveChanges();

            return RedirectToAction("Login"); // Redirige al login después de registrar
        }

        // Acción de usuarios: genera usuarios aleatorios y los pasa a la vista
        public IActionResult Usuarios()
        {
            // Generar lista de usuarios aleatorios
            var usuarios = GenerarUsuariosAleatorios();

            return View(usuarios); // Pasa la lista de usuarios a la vista
        }

        // Método para generar usuarios aleatorios
        private List<Usuario> GenerarUsuariosAleatorios()
        {
            var usuarios = new List<Usuario>();

            Random random = new Random();
            for (int i = 0; i < 10; i++) // Generar 10 usuarios aleatorios
            {
                var usuario = new Usuario
                {
                    NumeroCliente = $"CL-{random.Next(1000, 9999)}", // Número aleatorio de cliente
                    Cedula = random.Next(100000000, 999999999).ToString(),
                    Nombre = "Usuario " + (i + 1),
                    Email = "usuario" + (i + 1) + "@example.com",
                    Telefono = "300" + random.Next(1000000, 9999999),
                    Direccion = "Calle " + (i + 1) + ", Ciudad X"
                };
                usuarios.Add(usuario);
            }

            return usuarios;
        }
    }
}
