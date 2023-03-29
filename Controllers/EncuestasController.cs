﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChallengeSGB.Models;
using ChallengeSGB.Helpers;

namespace ChallengeSGB.Controllers
{
    public class EncuestasController : Controller
    {
        private readonly ChallengeContext _context;

        public EncuestasController(ChallengeContext context)
        {
            _context = context;
        }

        // GET: Encuestas
        public async Task<IActionResult> Index()
        {
              return _context.Encuestas != null ? 
                          View(await _context.Encuestas.ToListAsync()) :
                          Problem("Entity set 'ChallengeContext.Encuestas'  is null.");
        }

        // GET: Encuestas/promedy

        public async Task<IActionResult> Promedy()
        {
            List<Encuesta> encuestas = await _context.Encuestas.ToListAsync();
            if(encuestas.Count > 1)
            {
                int moviesSeen = 0;
                List<Period> periods = new List<Period>();
                foreach(var encuesta in encuestas)
                {
                    moviesSeen += encuesta.CantidadPeliculas ?? 0;
                    if(HelperFunctions.PeriodExists(encuesta.Periodo.ToString() , periods.ToArray()) == true)
                    {
                        periods.Find(period => period.period == encuesta.Periodo.ToString()).moviesSeen += encuesta.CantidadPeliculas ?? 0;
                    }
                }
            }

            return _context.Encuestas != null ?
                        View(await _context.Encuestas.ToListAsync()) :
                        Problem("Entity set 'ChallengeContext.Encuestas'  is null.");
        }

        // GET: Encuestas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Encuestas == null)
            {
                return NotFound();
            }

            var encuesta = await _context.Encuestas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (encuesta == null)
            {
                return NotFound();
            }

            return View(encuesta);
        }

        // GET: Encuestas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Encuestas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumeroUsuario,FechaNacimiento,Sexo,Periodo,CantidadPeliculas")] Encuesta encuesta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(encuesta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(encuesta);
        }

        // GET: Encuestas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Encuestas == null)
            {
                return NotFound();
            }

            var encuesta = await _context.Encuestas.FindAsync(id);
            if (encuesta == null)
            {
                return NotFound();
            }
            return View(encuesta);
        }

        // POST: Encuestas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumeroUsuario,FechaNacimiento,Sexo,Periodo,CantidadPeliculas")] Encuesta encuesta)
        {
            if (id != encuesta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(encuesta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EncuestaExists(encuesta.Id))
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
            return View(encuesta);
        }

        // GET: Encuestas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Encuestas == null)
            {
                return NotFound();
            }

            var encuesta = await _context.Encuestas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (encuesta == null)
            {
                return NotFound();
            }

            return View(encuesta);
        }

        // POST: Encuestas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Encuestas == null)
            {
                return Problem("Entity set 'ChallengeContext.Encuestas'  is null.");
            }
            var encuesta = await _context.Encuestas.FindAsync(id);
            if (encuesta != null)
            {
                _context.Encuestas.Remove(encuesta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EncuestaExists(int id)
        {
          return (_context.Encuestas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}