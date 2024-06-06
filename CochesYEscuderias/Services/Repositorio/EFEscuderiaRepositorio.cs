using CochesYEscuderias.Models;
using Microsoft.EntityFrameworkCore;

namespace CochesYEscuderias.Services.Repositorio
{
    public class EFEscuderiaRepositorio :IEscuderiaRepositorio
    {
        public readonly CochesContext _context = new();

        public List<Escuderia> DameTodos()
        {
            return _context.Escuderias.AsNoTracking().ToList();
        }

        public Escuderia? DameUno(int Id)
        {
            return _context.Escuderias.Find(Id);
        }

        public bool Borrar(int Id)
        {
            if (DameUno(Id) != null)
            {
                _context.Escuderias.Remove(DameUno(Id));
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Agregar(Escuderia escuderia)
        {
            if (DameUno(escuderia.Id) != null)
            {

                return false;
            }
            else
            {
                _context.Escuderias.Add(escuderia);
                _context.SaveChanges();
                return true;
            }
        }

        public void Modificar(int Id, Escuderia escuderia)
        {
            var respuesta = DameUno(Id);
            if (respuesta != null)
            {
                Borrar(Id);
                _context.SaveChanges();
            }
            Agregar(escuderia);
            _context.SaveChanges();
        }
    }
}
