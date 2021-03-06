﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChinookAPI.Models;

namespace ChinookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistasController : ControllerBase
    {
        private readonly ChinookContext _context;

        public ArtistasController(ChinookContext context)
        {
            _context = context;
        }

        // GET: api/Artistas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artista>>> GetArtista()
        {
            return await _context.Artista.ToListAsync();
        }

        // GET: api/Artistas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artista>> GetArtista(int id)
        {
            var artista = await _context.Artista.FindAsync(id);

            if (artista == null)
            {
                return NotFound();
            }

            return artista;
        }

        //GET: api/Artistas/nombre/NombreArtista
        [HttpGet("nombre/{nombre}")]
        public async Task<ActionResult<IEnumerable<Artista>>> GetArtistaNombre(string nombre)
        {
            var artista = _context.Artista.AsQueryable();

            if (nombre != null)
            {
                artista = _context.Artista.Where(c => c.Nombre.Equals(nombre));
            }

            return await artista.ToListAsync();
        }

        // PUT: api/Artistas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtista(int id, Artista artista)
        {
            if (id != artista.ArtistaId)
            {
                return BadRequest();
            }

            _context.Entry(artista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Artistas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Artista>> PostArtista(Artista artista)
        {
            _context.Artista.Add(artista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtista", new { id = artista.ArtistaId }, artista);
        }

        // DELETE: api/Artistas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Artista>> DeleteArtista(int id)
        {
            var artista = await _context.Artista.FindAsync(id);
            if (artista == null)
            {
                return NotFound();
            }

            _context.Artista.Remove(artista);
            await _context.SaveChangesAsync();

            return artista;
        }

        private bool ArtistaExists(int id)
        {
            return _context.Artista.Any(e => e.ArtistaId == id);
        }
    }
}
