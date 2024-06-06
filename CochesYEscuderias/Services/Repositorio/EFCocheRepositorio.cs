using CochesYEscuderias.Models;
using Microsoft.EntityFrameworkCore;

namespace CochesYEscuderias.Services.Repositorio
{
    public class EFCocheRepositorio :ICocheRepositorio
    {
        public readonly CochesContext _context =new();

        public List<Coche> DameTodos()
        {
            return _context.Coches.AsNoTracking().ToList();
        }

        public Coche? DameUno(int Id)
        {
            return _context.Coches.Find(Id);
        }

        public bool Borrar(int Id)
        {
            if (DameUno(Id) != null)
            {
                _context.Coches.Remove(DameUno(Id));
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Agregar(Coche coche)
        {
            if (DameUno(coche.Id) != null)
            {

                return false;
            }
            else
            {
                _context.Coches.Add(coche);
                _context.SaveChanges();
                return true;
            }
        }

        public void Modificar(int Id, Coche coche)
        {
            var respuesta = DameUno(Id);
            if (respuesta != null)
            {
                Borrar(Id);
                _context.SaveChanges();
            }
            Agregar(coche);
            _context.SaveChanges();
        }
    }
}
