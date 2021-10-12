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
    public class ActorsController : Controller
    {
        private readonly IActorService _service;

        public ActorsController(IActorService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Actors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);

            if (actorDetails is null) return View("NotFound");
            return View(actorDetails);
        }
        
        //Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,Bio,ProfilePictureURL")] Actor actor)
        {
            if (!ModelState.IsValid)
                return View(actor);
            /** 
             * Si hay errores en la validación de datos
             * retorna la misma vista con los mensajes de error
             * del ModelState
             */

            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Edit
        public async Task<IActionResult> EditAsync(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails is null) return View("NotFoud");
            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,FullName,Bio,ProfilePictureURL")] Actor actor)
        {
            if (!ModelState.IsValid) return View(actor);

            await _service.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }
    }
}
