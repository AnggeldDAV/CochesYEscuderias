using CochesYEscuderias.Models;
using Microsoft.EntityFrameworkCore;

namespace CochesYEscuderias.Services.Repositorio
{
    public class FakeEscuderiaRepositorio: IRepositorio<Escuderia>
    {
        List<Escuderia>listaEscuderias = new();

        public FakeEscuderiaRepositorio()
        {
            var miEscuderia = new Escuderia()
            {
                Nombre = "Ferrari",
                Dinero = 7000
            };
            listaEscuderias.Add(miEscuderia);
            var miEscuderia2 = new Escuderia()
            {
                Nombre = "Ford",
                Dinero = 1200
            };
            listaEscuderias.Add(miEscuderia2);
            var miEscuderia3 = new Escuderia()
            {
                Nombre = "Mustang",
                Dinero = 800
            };
            listaEscuderias.Add(miEscuderia3);
            var miEscuderia4 = new Escuderia()
            {
                Nombre = "Redbull",
                Dinero = 2000
            };
            listaEscuderias.Add(miEscuderia4);
            var miEscuderia5 = new Escuderia()
            {
                Nombre = "Manolo",
                Dinero = 80
            };
            listaEscuderias.Add(miEscuderia5);
        }
        public List<Escuderia> DameTodos()
        {
            return listaEscuderias; 
        }

        public Escuderia? DameUno(int Id)
        {
            return listaEscuderias.FirstOrDefault(x => x.Id == Id);
        }

        public bool Borrar(int Id)
        {
            if (DameUno(Id) != null)
            {
               listaEscuderias.Remove(DameUno(Id));
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Agregar(Escuderia Object)
        {
            if (DameUno(Object.Id) != null)
            {

                return false;
            }
            else
            {
                listaEscuderias.Add(Object);
                return true;
            }
        }

        public void Modificar(int Id, Escuderia Object)
        {
            var respuesta = DameUno(Id);
            if (respuesta != null)
            {
                Borrar(Id);
            }
            Agregar(Object);
        }
    }
}
