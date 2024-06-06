using CochesYEscuderias.Models;

namespace CochesYEscuderias.Services.Repositorio
{
    public interface ICocheRepositorio
    {
        List<Coche> DameTodos();
        Coche? DameUno(int Id);
        bool Borrar(int Id);
        bool Agregar(Coche coche);
        void Modificar(int Id, Coche coche);

    }
}
