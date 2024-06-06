using CochesYEscuderias.Models;

namespace CochesYEscuderias.Services.Repositorio
{
    public interface IEscuderiaRepositorio
    {
        List<Escuderia> DameTodos();
        Escuderia? DameUno(int Id);
        bool Borrar(int Id);
        bool Agregar(Escuderia escuderia);
        void Modificar(int Id, Escuderia escuderia);
    }
}
