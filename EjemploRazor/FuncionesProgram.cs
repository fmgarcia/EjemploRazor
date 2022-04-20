
using EjemploRazor.Utilidades;
using EjemploRazor.Models;
using EjemploRazor.Data;

namespace EjemploRazor
{
    public static class FuncionesProgram
    {

        public static readonly Data.EjemploRazorContext Context = new EjemploRazorContext();

        public static void LeerEspecializacionesPro()
        {
            List<int> numeros = JsonUtils.DevolverListaGenerica<int>(@"https://api.guildwars2.com/v2/specializations?lang=es");
            foreach (int numero in numeros)
            {
                Especializacion especializacion = JsonUtils.DevolverObjetoGenerico<Especializacion>(@"https://api.guildwars2.com/v2/specializations/" + numero + "?lang=es");
                Context.Especializacion.Add(especializacion);
                Context.SaveChanges();
                //especializaciones.Add(especializacion);
            }
        }

    }
}
