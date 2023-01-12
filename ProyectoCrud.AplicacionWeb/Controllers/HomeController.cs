using Microsoft.AspNetCore.Mvc;
using ProyectoCrud.AplicacionWeb.Models;
using ProyectoCrud.AplicacionWeb.Models.ViewModels;
using ProyectoCrud.BLL.Service;
using ProyectoCrud.Models;
using System.Diagnostics;
using System.Globalization;

namespace ProyectoCrud.AplicacionWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContactoService _contactosService;


        public HomeController(ILogger<HomeController> logger, IContactoService contactosService)
        {
            _logger = logger;
            _contactosService = contactosService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            IQueryable<Contacto> queryContactoSQL = await _contactosService.GetAll();

            List<VMContacto> lista = queryContactoSQL.Select(c => new VMContacto()
            {
                IdContacto = c.IdContacto,
                Nombre = c.Nombre,
                Telefono = c.Telefono, 
                FechaNacimiento = c.FechaNacimiento.Value.ToString("dd/MM/yyyy")
            }).ToList();

            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]VMContacto modelo)
        {
            Contacto nuevoModelo = new Contacto()
            {
                Nombre = modelo.Nombre,
                Telefono = modelo.Telefono,
                FechaNacimiento = DateTime.ParseExact(modelo.FechaNacimiento, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-PE"))
          };

            bool respuesta = await _contactosService.Insert(nuevoModelo); 



            return StatusCode(StatusCodes.Status200OK, new
            {
                valor = respuesta
            });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] VMContacto modelo)
        {
            Contacto nuevoModelo = new Contacto()
            {
                IdContacto = modelo.IdContacto,
                Nombre = modelo.Nombre,
                Telefono = modelo.Telefono,
                FechaNacimiento = DateTime.ParseExact(modelo.FechaNacimiento, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-PE"))
            };

            bool respuesta = await _contactosService.Update(nuevoModelo);



            return StatusCode(StatusCodes.Status200OK, new
            {
                valor = respuesta
            });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            
            bool respuesta = await _contactosService.Delete(id);



            return StatusCode(StatusCodes.Status200OK, new
            {
                valor = respuesta
            });
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}