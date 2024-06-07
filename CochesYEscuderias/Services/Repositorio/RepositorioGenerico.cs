using CochesYEscuderias.Models;
using Microsoft.EntityFrameworkCore;

namespace CochesYEscuderias.Services.Repositorio
{
    public class RepositorioGenerico<T> : IRepositorio<T> where T: class
    {
        private readonly CochesContext _context = new();
        public List<T> DameTodos()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }

        public T? DameUno(int Id)
        {
            return _context.Set<T>().Find(Id);
        }

        public bool Borrar(int Id)
        {
            _context.Set<T>().Remove(DameUno((int)Id));
            _context.SaveChanges();
            return true;
        }

        public bool Agregar(T Object)
        {
            _context.Set<T>().Add(Object);
            _context.SaveChanges();
            return true;
        }

        public void Modificar(int Id, T Object)
        {
            _context.Set<T>().Remove(Object);
            _context.Set<T>().Add(Object);
        }
    }
}
