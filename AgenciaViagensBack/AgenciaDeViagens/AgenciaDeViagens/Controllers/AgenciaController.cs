using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgenciaDeViagens.Models;

namespace AgenciaDeViagens.Data
{
    public class AgenciaController : Controller
    {
        private readonly AgenciaDeViagensContext _context;

        public AgenciaController(AgenciaDeViagensContext context)
        {
            _context = context;
        }

        // GET: Agencia
        public async Task<IActionResult> Index()
        {
            var agenciaDeViagensContext = _context.Agencia.Include(a => a.Cliente).Include(a => a.Destino);
            return View(await agenciaDeViagensContext.ToListAsync());
        }

        // GET: Agencia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agencia = await _context.Agencia
                .Include(a => a.Cliente)
                .Include(a => a.Destino)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (agencia == null)
            {
                return NotFound();
            }

            return View(agencia);
        }

        // GET: Agencia/Create
        public IActionResult Create()
        {
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ID", "Cpf");
            ViewData["DestinoID"] = new SelectList(_context.Destino, "ID", "Data");
            return View();
        }

        // POST: Agencia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Passaporte,PrecoPromo,ClienteID,DestinoID")] Agencia agencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ID", "Cpf", agencia.ClienteID);
            ViewData["DestinoID"] = new SelectList(_context.Destino, "ID", "Data", agencia.DestinoID);
            return View(agencia);
        }

        // GET: Agencia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agencia = await _context.Agencia.FindAsync(id);
            if (agencia == null)
            {
                return NotFound();
            }
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ID", "Cpf", agencia.ClienteID);
            ViewData["DestinoID"] = new SelectList(_context.Destino, "ID", "Data", agencia.DestinoID);
            return View(agencia);
        }

        // POST: Agencia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Passaporte,PrecoPromo,ClienteID,DestinoID")] Agencia agencia)
        {
            if (id != agencia.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgenciaExists(agencia.ID))
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
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ID", "Cpf", agencia.ClienteID);
            ViewData["DestinoID"] = new SelectList(_context.Destino, "ID", "Data", agencia.DestinoID);
            return View(agencia);
        }

        // GET: Agencia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agencia = await _context.Agencia
                .Include(a => a.Cliente)
                .Include(a => a.Destino)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (agencia == null)
            {
                return NotFound();
            }

            return View(agencia);
        }

        // POST: Agencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agencia = await _context.Agencia.FindAsync(id);
            _context.Agencia.Remove(agencia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgenciaExists(int id)
        {
            return _context.Agencia.Any(e => e.ID == id);
        }
    }
}
