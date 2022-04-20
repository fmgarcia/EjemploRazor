using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploRazor.Models
{

    public class Especializacion
    {
        public int id { get; set; }
        public string name { get; set; } = String.Empty;
        public string profession { get; set; } = String.Empty;
        public bool elite { get; set; }
        public string icon { get; set; } = String.Empty;
        public string background { get; set; } = String.Empty;

        public Especializacion()
        {

        }

        public Especializacion(int id, string name, string profession, bool elite, string icon, string background)
        {
            this.id = id;
            this.name = name;
            this.profession = profession;
            this.elite = elite;
            this.icon = icon;
            this.background = background;
        }

        public override string ToString()
        {
            return $"Id: {id} Nombre: {name}";
        }
    }
}
