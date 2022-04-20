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
    public class IndexModel : PageModel
    {
        private readonly EjemploRazor.Data.EjemploRazorContext _context;

        public IndexModel(EjemploRazor.Data.EjemploRazorContext context)
        {
            _context = context;
        }

        public IList<Especializacion> Especializacion { get;set; }

        public async Task OnGetAsync()
        {
            Especializacion = await _context.Especializacion.ToListAsync();
        }
    }
}
