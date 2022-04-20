#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EjemploRazor.Data;
using EjemploRazor.Models;

namespace EjemploRazor.Pages.Especializaciones
{
    public class CreateModel : PageModel
    {
        private readonly EjemploRazor.Data.EjemploRazorContext _context;

        public CreateModel(EjemploRazor.Data.EjemploRazorContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Especializacion Especializacion { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Especializacion.Add(Especializacion);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
