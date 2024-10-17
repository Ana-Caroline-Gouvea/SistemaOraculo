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
    public class PostagemController : Controller
    {
        private readonly Contexto _context;

        public PostagemController(Contexto context)
        {
            _context = context;
        }

        // GET: Postagem
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Postagem.Include(p => p.Categorias)
                .Include(p => p.Comunidades);
            return View(await contexto.ToListAsync());
        }

        // GET: Postagem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Postagem == null)
            {
                return NotFound();
            }

            var postagem = await _context.Postagem
                .Include(p => p.Categorias)
                .FirstOrDefaultAsync(m => m.PostagemId == id);
            if (postagem == null)
            {
                return NotFound();
            }

            return View(postagem);
        }

        // GET: Postagem/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome");
            ViewData["ComunidadesId"] = new SelectList(_context.Comunidades, "ComunidadesId", "NomeComunidade");
            return View();
        }

        // POST: Postagem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostagemId,ComunidadesId,CategoriaId,Like,Compartilhamento,PostagemNome,PostagemImg")] Postagem postagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", postagem.CategoriaId);
            ViewData["ComunidadesId"] = new SelectList(_context.Comunidades, "ComunidadesId", "NomeComunidade");
            return View(postagem);
        }

        // GET: Postagem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Postagem == null)
            {
                return NotFound();
            }

            var postagem = await _context.Postagem.FindAsync(id);
            if (postagem == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", postagem.CategoriaId);
            return View(postagem);
        }

        // POST: Postagem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostagemId,ComunidadeId,CategoriaId,Like,Compartilhamento,PostagemNome,PostagemImg")] Postagem postagem)
        {
            if (id != postagem.PostagemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostagemExists(postagem.PostagemId))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", postagem.CategoriaId);
            return View(postagem);
        }

        // GET: Postagem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Postagem == null)
            {
                return NotFound();
            }

            var postagem = await _context.Postagem
                .Include(p => p.Categorias)
                .FirstOrDefaultAsync(m => m.PostagemId == id);
            if (postagem == null)
            {
                return NotFound();
            }

            return View(postagem);
        }

        // POST: Postagem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Postagem == null)
            {
                return Problem("Entity set 'Contexto.Postagem'  is null.");
            }
            var postagem = await _context.Postagem.FindAsync(id);
            if (postagem != null)
            {
                _context.Postagem.Remove(postagem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostagemExists(int id)
        {
          return (_context.Postagem?.Any(e => e.PostagemId == id)).GetValueOrDefault();
        }
    }
}
