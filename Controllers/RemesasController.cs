using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EP_RODRIGUEZ.Models;
using EP_RODRIGUEZ.Data;
using EP_RODRIGUEZ.ViewModel;

namespace EP_RODRIGUEZ.Controllers
{
    public class RemesasController : Controller
    {
        private readonly ILogger<RemesasController> _logger;
        private readonly ApplicationDbContext _context;

        public RemesasController(ILogger<RemesasController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
           var misremesas = from o in _context.DataRemesas select o;
            _logger.LogDebug("remesas {misremesas}", misremesas);
            var viewModel = new RemesasViewModel
            {
                FormRemesas = new Remesas(),
                ListRemesas = misremesas
            };
            _logger.LogDebug("viewModel {viewModel}", viewModel);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Crear(RemesasViewModel viewModel)
        {
            _logger.LogDebug("Ingreso a Crear Remesa");

            var remesas = new Remesas
            {
                NombreR = viewModel.FormRemesas.NombreR,
                NombreD = viewModel.FormRemesas.NombreD,
                Origen = viewModel.FormRemesas.Origen,
                Destino = viewModel.FormRemesas.Destino,
                Monto = viewModel.FormRemesas.Monto,
                TipoM = viewModel.FormRemesas.TipoM,
                Tasa = viewModel.FormRemesas.Tasa,
                MontoF = viewModel.FormRemesas.MontoF,
                EstadoT = viewModel.FormRemesas.EstadoT,
            };

            _context.Add(remesas);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult List(){
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}