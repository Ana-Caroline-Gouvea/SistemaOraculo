using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Oraculo.Models;

namespace Oraculo.Controllers
{
    public class MaisComentadosController : Controller
    {
        private readonly Contexto _context;

        public MaisComentadosController(Contexto context)
        {
            _context = context;
        }

        // GET: MaisComentados
        public async Task<IActionResult> Index()
        {
            var contexto = _context.MaisComentados.Include(m => m.Postagem);
            return View(await contexto.ToListAsync());
        }

        // GET: MaisComentados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MaisComentados == null)
            {
                return NotFound();
            }

            var maisComentados = await _context.MaisComentados
                .Include(m => m.Postagem)
                .FirstOrDefaultAsync(m => m.MaisComentadosId == id);
            if (maisComentados == null)
            {
                return NotFound();
            }

            return View(maisComentados);
        }

        // GET: MaisComentados/Create
        public IActionResult Create()
        {
            ViewData["PostagemId"] = new SelectList(_context.Postagem, "PostagemId", "PostagemId");
            return View();
        }

        // POST: MaisComentados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaisComentadosId,PostagemId")] MaisComentados maisComentados)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maisComentados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PostagemId"] = new SelectList(_context.Postagem, "PostagemId", "PostagemId", maisComentados.PostagemId);
            return View(maisComentados);
        }

        // GET: MaisComentados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MaisComentados == null)
            {
                return NotFound();
            }

            var maisComentados = await _context.MaisComentados.FindAsync(id);
            if (maisComentados == null)
            {
                return NotFound();
            }
            ViewData["PostagemId"] = new SelectList(_context.Postagem, "PostagemId", "PostagemId", maisComentados.PostagemId);
            return View(maisComentados);
        }

        // POST: MaisComentados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaisComentadosId,PostagemId")] MaisComentados maisComentados)
        {
            if (id != maisComentados.MaisComentadosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maisComentados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaisComentadosExists(maisComentados.MaisComentadosId))
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
            ViewData["PostagemId"] = new SelectList(_context.Postagem, "PostagemId", "PostagemId", maisComentados.PostagemId);
            return View(maisComentados);
        }

        // GET: MaisComentados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MaisComentados == null)
            {
                return NotFound();
            }

            var maisComentados = await _context.MaisComentados
                .Include(m => m.Postagem)
                .FirstOrDefaultAsync(m => m.MaisComentadosId == id);
            if (maisComentados == null)
            {
                return NotFound();
            }

            return View(maisComentados);
        }

        // POST: MaisComentados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MaisComentados == null)
            {
                return Problem("Entity set 'Contexto.MaisComentados'  is null.");
            }
            var maisComentados = await _context.MaisComentados.FindAsync(id);
            if (maisComentados != null)
            {
                _context.MaisComentados.Remove(maisComentados);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaisComentadosExists(int id)
        {
          return (_context.MaisComentados?.Any(e => e.MaisComentadosId == id)).GetValueOrDefault();
        }
    }
}
