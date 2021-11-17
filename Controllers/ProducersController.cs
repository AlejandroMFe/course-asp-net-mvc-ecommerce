using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducerService _service;

        public ProducersController(IProducerService service) => _service = service;

        public async Task<IActionResult> Index()
        {
            //var data = await _context.Producers.ToListAsync();
            var data = await _service.GetAllAsync();
            return View(data);

            //si deseo retorna otra vista, lo puedo hacer así
            //return View("OtroIndex", data);
        }

        // Get: producer/details/1
        public async Task<IActionResult> Details(int id)
        {
            var producerDatils = await _service.GetByIdAsync(id);

            if (producerDatils is null) return View("NotFound");
            return View(producerDatils);
        }

        // Get: producer/edit/1
        public async Task<IActionResult> EditAsync(int id)
        {
            var producer = await _service.GetByIdAsync(id);
            if (producer is null) return View("NotFound");
            return View(producer);
        }

        // Post: producer/update/1
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind] Producer producer)
        {
            if(!ModelState.IsValid) return View(producer);

            await _service.UpdateAsync(id, producer);
            return RedirectToAction(nameof(Index));
        }
    }
}
