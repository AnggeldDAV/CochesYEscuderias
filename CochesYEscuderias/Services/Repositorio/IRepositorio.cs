using CochesYEscuderias.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CochesYEscuderias.Services.Repositorio
{
    public interface IRepositorio<T> where T : class
    {
        List<T> DameTodos();
        T? DameUno(int Id);
        bool Borrar(int Id);
        bool Agregar(T Object);
        void Modificar(int Id, T Object);
    }
}
