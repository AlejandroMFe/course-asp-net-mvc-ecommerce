﻿using eTickets.Data;
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

        // Get: producer/create/1
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL, Bio, FullName")] Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);

            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        // Get: producer/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails is null) return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, ProfilePictureURL, Bio, FullName")] Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);

            if (id == producer.Id)
            {
                await _service.UpdateAsync(id, producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }

        // Get: producer/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails is null) return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async  Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails is null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
