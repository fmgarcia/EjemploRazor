#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EjemploRazor.Data;
using EjemploRazor.Models;

namespace EjemploRazor.Pages.Especializaciones
{
    public class DetailsModel : PageModel
    {
        private readonly EjemploRazor.Data.EjemploRazorContext _context;

        public DetailsModel(EjemploRazor.Data.EjemploRazorContext context)
        {
            _context = context;
        }

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
    }
}
