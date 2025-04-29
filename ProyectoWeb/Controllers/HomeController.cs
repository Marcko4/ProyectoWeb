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

        private static List<Libro> libros = new List<Libro>
{
    new Libro
    {
        Id = 1,
        Nombre = "El poder del ahora",
        Autor = "Eckhart Tolle",
        Idioma = "Español",
        PrecioVenta = 150000,
        Descripcion = "Una guía hacia la iluminación espiritual y el momento presente.",
        ImagenUrl = "/images/Elpoderdelahora.jpg",
        Codigo = "LIB001",
        PrecioAlquiler = 30000,
        Categoria = "Espiritualidad",
    },

new Libro
{
    Id = 2,
    Nombre = "Hábitos Atómicos",
    Autor = "James Clear",
    Idioma = "Español",
    PrecioVenta = 120000,
    PrecioAlquiler = 25000,
    Disponible = true,
    Categoria = "Desarrollo personal",
    Codigo = "LIB002",
    Descripcion = "Transforma tu vida con pequeños hábitos diarios.",
    ImagenUrl = "/images/Habitosatomicosjpg.jpg"
},
new Libro
{
    Id = 3,
    Nombre = "Cómo hacer que te pasen cosas buenas",
    Autor = "Marian Rojas Estapé",
    Idioma = "Español",
    PrecioVenta = 190000,
    PrecioAlquiler = 35000,
    Disponible = true,
    Categoria = "Autoayuda",
    Codigo = "LIB003",
    Descripcion = "Conecta ciencia y emociones para una vida mejor.",
    ImagenUrl = "/images/Comohacerquetepasencosasbuenas.jpg"
},
new Libro
{
    Id = 4,
    Nombre = "La Inteligencia Emocional",
    Autor = "Daniel Goleman",
    Idioma = "Español",
    PrecioVenta = 150000,
    PrecioAlquiler = 30000,
    Disponible = true,
    Categoria = "Psicología",
    Codigo = "LIB004",
    Descripcion = "Explora el impacto de las emociones en la inteligencia humana.",
    ImagenUrl = "/images/Lainteligenciaemocional.jpg"
},
new Libro
{
    Id = 5,
    Nombre = "El Extranjero",
    Autor = "Albert Camus",
    Idioma = "Español",
    PrecioVenta = 135000,
    PrecioAlquiler = 25000,
    Disponible = true,
    Categoria = "Novela",
    Codigo = "LIB005",
    Descripcion = "Una reflexión sobre el absurdo de la existencia humana.",
    ImagenUrl = "/images/Elextranjero.jpg"
},
new Libro
{
    Id = 6,
    Nombre = "Encuentra tu persona vitamina",
    Autor = "Marian Rojas Estapé",
    Idioma = "Español",
    PrecioVenta = 160000,
    PrecioAlquiler = 32000,
    Disponible = true,
    Categoria = "Autoayuda",
    Codigo = "LIB006",
    Descripcion = "Descubre personas que potencian tu bienestar emocional.",
    ImagenUrl = "/images/Personavitamina.jpg"
},
new Libro
{
    Id = 7,
    Nombre = "Padre Rico Padre Pobre",
    Autor = "Robert Kiyosaki",
    Idioma = "Español",
    PrecioVenta = 170000,
    PrecioAlquiler = 33000,
    Disponible = true,
    Categoria = "Finanzas personales",
    Codigo = "LIB007",
    Descripcion = "Lecciones financieras para lograr la independencia económica.",
    ImagenUrl = "/images/Padrericopadrepobre.jpg"
},
new Libro
{
    Id = 8,
    Nombre = "El inversor inteligente",
    Autor = "Benjamin Graham",
    Idioma = "Español",
    PrecioVenta = 200000,
    PrecioAlquiler = 40000,
    Disponible = true,
    Categoria = "Finanzas",
    Codigo = "LIB008",
    Descripcion = "Guía clásica para invertir de forma segura y efectiva.",
    ImagenUrl = "/images/Elinversorinteligente.jpg"
},
new Libro
{
    Id = 9,
    Nombre = "La Felicidad",
    Autor = "Bertrand Russell",
    Idioma = "Español",
    PrecioVenta = 140000,
    PrecioAlquiler = 28000,
    Disponible = true,
    Categoria = "Filosofía",
    Codigo = "LIB009",
    Descripcion = "Una reflexión profunda sobre la naturaleza de la felicidad.",
    ImagenUrl = "/images/Lafelicidad.jpg"
},
new Libro
{
    Id = 10,
    Nombre = "Los secretos de la mente millonaria",
    Autor = "T. Harv Eker",
    Idioma = "Español",
    PrecioVenta = 180000,
    PrecioAlquiler = 35000,
    Disponible = true,
    Categoria = "Desarrollo personal",
    Codigo = "LIB010",
    Descripcion = "Cómo cambiar tu mentalidad para alcanzar la riqueza.",
    ImagenUrl = "/images/Secretosmentemillonaria.jpg"
},

    // Podés seguir agregando más libros después
};
        public IActionResult DetalleLibro(int id)
        {
            var Libro = libros.FirstOrDefault(l => l.Id == id);

            if (Libro == null)
            {
                return NotFound();
            }

            return View(Libro);
        }


    }
}
