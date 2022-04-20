#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EjemploRazor.Data;
using EjemploRazor.Models;

namespace EjemploRazor.Pages.Especializaciones
{
    public class EditModel : PageModel
    {
        private readonly EjemploRazor.Data.EjemploRazorContext _context;

        public EditModel(EjemploRazor.Data.EjemploRazorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Especializacion Especializacion { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Especializacion = await _context.Especializacion.FirstOrDefaultAsync(m => m.id == id);

            if (Especializacion == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Especializacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspecializacionExists(Especializacion.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EspecializacionExists(int id)
        {
            return _context.Especializacion.Any(e => e.id == id);
        }
    }
}
