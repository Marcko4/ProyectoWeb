using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProyectoWeb.Models;
using System.Collections.Generic;

namespace ProyectoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Variable est�tica para contar el n�mero de clientes registrados
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

        // P�gina de error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Vista de inicio (si la us�s)
        public IActionResult Inicio()
        {
            return View();
        }

        // Vista de login
        [HttpGet]
        public IActionResult Login()
        {
            return View(); // Buscar� Views/Home/Login.cshtml
        }

        // Vista de registro
        [HttpGet]
        public IActionResult Registro()
        {
            return View(); // Buscar� Views/Home/Registro.cshtml
        }

        // Recibe los datos del formulario de registro y genera un n�mero de cliente
        [HttpPost]
        public IActionResult Guardar(string fullName, string cedula, string email, string phone, string address)
        {
            // Generaci�n del n�mero de cliente
            string numeroCliente = $"CL-{contadorCliente.ToString("D4")}";
            contadorCliente++; // Aumenta el contador para el siguiente cliente

            // Guardar los datos temporalmente
            TempData["Mensaje"] = $"�Registro exitoso! Tu n�mero de cliente es {numeroCliente}.";

           

            return RedirectToAction("Login"); // Redirige al login despu�s de registrar
        }

        // Acci�n de usuarios: genera usuarios aleatorios y los pasa a la vista
        public IActionResult Usuarios()
        {
            // Generar lista de usuarios aleatorios
            var usuarios = GenerarUsuariosAleatorios();

            return View(usuarios); // Pasa la lista de usuarios a la vista
        }

        // M�todo para generar usuarios aleatorios
        private List<Usuario> GenerarUsuariosAleatorios()
        {
            var usuarios = new List<Usuario>();

            Random random = new Random();
            for (int i = 0; i < 10; i++) // Generar 10 usuarios aleatorios
            {
                var usuario = new Usuario
                {
                    NumeroCliente = $"CL-{random.Next(1000, 9999)}", // N�mero aleatorio de cliente
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
        Idioma = "Espa�ol",
        PrecioVenta = 150000,
        Descripcion = "Una gu�a hacia la iluminaci�n espiritual y el momento presente.",
        ImagenUrl = "/images/Elpoderdelahora.jpg",
        Codigo = "LIB001",
        PrecioAlquiler = 30000,
        Categoria = "Espiritualidad",
    },

new Libro
{
    Id = 2,
    Nombre = "H�bitos At�micos",
    Autor = "James Clear",
    Idioma = "Espa�ol",
    PrecioVenta = 120000,
    PrecioAlquiler = 25000,
    Disponible = true,
    Categoria = "Desarrollo personal",
    Codigo = "LIB002",
    Descripcion = "Transforma tu vida con peque�os h�bitos diarios.",
    ImagenUrl = "/images/Habitosatomicosjpg.jpg"
},
new Libro
{
    Id = 3,
    Nombre = "C�mo hacer que te pasen cosas buenas",
    Autor = "Marian Rojas Estap�",
    Idioma = "Espa�ol",
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
    Idioma = "Espa�ol",
    PrecioVenta = 150000,
    PrecioAlquiler = 30000,
    Disponible = true,
    Categoria = "Psicolog�a",
    Codigo = "LIB004",
    Descripcion = "Explora el impacto de las emociones en la inteligencia humana.",
    ImagenUrl = "/images/Lainteligenciaemocional.jpg"
},
new Libro
{
    Id = 5,
    Nombre = "El Extranjero",
    Autor = "Albert Camus",
    Idioma = "Espa�ol",
    PrecioVenta = 135000,
    PrecioAlquiler = 25000,
    Disponible = true,
    Categoria = "Novela",
    Codigo = "LIB005",
    Descripcion = "Una reflexi�n sobre el absurdo de la existencia humana.",
    ImagenUrl = "/images/Elextranjero.jpg"
},
new Libro
{
    Id = 6,
    Nombre = "Encuentra tu persona vitamina",
    Autor = "Marian Rojas Estap�",
    Idioma = "Espa�ol",
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
    Idioma = "Espa�ol",
    PrecioVenta = 170000,
    PrecioAlquiler = 33000,
    Disponible = true,
    Categoria = "Finanzas personales",
    Codigo = "LIB007",
    Descripcion = "Lecciones financieras para lograr la independencia econ�mica.",
    ImagenUrl = "/images/Padrericopadrepobre.jpg"
},
new Libro
{
    Id = 8,
    Nombre = "El inversor inteligente",
    Autor = "Benjamin Graham",
    Idioma = "Espa�ol",
    PrecioVenta = 200000,
    PrecioAlquiler = 40000,
    Disponible = true,
    Categoria = "Finanzas",
    Codigo = "LIB008",
    Descripcion = "Gu�a cl�sica para invertir de forma segura y efectiva.",
    ImagenUrl = "/images/Elinversorinteligente.jpg"
},
new Libro
{
    Id = 9,
    Nombre = "La Felicidad",
    Autor = "Bertrand Russell",
    Idioma = "Espa�ol",
    PrecioVenta = 140000,
    PrecioAlquiler = 28000,
    Disponible = true,
    Categoria = "Filosof�a",
    Codigo = "LIB009",
    Descripcion = "Una reflexi�n profunda sobre la naturaleza de la felicidad.",
    ImagenUrl = "/images/Lafelicidad.jpg"
},
new Libro
{
    Id = 10,
    Nombre = "Los secretos de la mente millonaria",
    Autor = "T. Harv Eker",
    Idioma = "Espa�ol",
    PrecioVenta = 180000,
    PrecioAlquiler = 35000,
    Disponible = true,
    Categoria = "Desarrollo personal",
    Codigo = "LIB010",
    Descripcion = "C�mo cambiar tu mentalidad para alcanzar la riqueza.",
    ImagenUrl = "/images/Secretosmentemillonaria.jpg"
},

    // Pod�s seguir agregando m�s libros despu�s
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
