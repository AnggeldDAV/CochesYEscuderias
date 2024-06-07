using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CochesYEscuderias.Models;
using CochesYEscuderias.Services.Repositorio;

namespace CochesYEscuderias.Controllers
{
    public class CochesController : Controller
    {
        private readonly IRepositorio<Coche> _repositorio;
        private readonly IRepositorio<Escuderia> _repositorio2;

        public CochesController(IRepositorio<Coche> repositorio, IRepositorio<Escuderia> repositorio2)
        {
            _repositorio = repositorio;
            _repositorio2 = repositorio2;
        }

        // GET: Coches
        public async Task<IActionResult> Index()
        {
            return View(_repositorio.DameTodos());
        }

        // GET: Coches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coche = _repositorio.DameUno((int)id);
            if (coche == null)
            {
                return NotFound();
            }

            return View(coche);
        }

        // GET: Coches/Create
        public IActionResult Create()
        {
            ViewData["EscuderiaId"] = new SelectList(_repositorio2.DameTodos(), "Id", "Nombre");
            return View();
        }

        // POST: Coches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Motor,Nombre,EscuderiaId")] Coche coche)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Agregar(coche);
                return RedirectToAction(nameof(Index));
            }

            return View(coche);
        }

        // GET: Coches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coche = _repositorio.DameUno((int)id);
            if (coche == null)
            {
                return NotFound();
            }
            return View(coche);
        }

        // POST: Coches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Motor,Nombre,EscuderiaId")] Coche coche)
        {
            if (id != coche.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repositorio.Modificar((int)id,coche);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CocheExists(coche.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(coche);
        }

        // GET: Coches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coche = _repositorio.DameUno((int)id);
            if (coche == null)
            {
                return NotFound();
            }

            return View(coche);
        }

        // POST: Coches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coche = _repositorio.DameUno((int)id);
            if (coche != null)
            {
                _repositorio.Borrar((int)id);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool CocheExists(int id)
        {
            if (_repositorio.DameUno((int)id) == null)
                return false;
            else
            {
                return true;
            }
        }
    }
}
