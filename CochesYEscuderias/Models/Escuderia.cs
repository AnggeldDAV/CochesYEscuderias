namespace CochesYEscuderias.Models
{
    public class Escuderia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Dinero { get; set; }
        public virtual ICollection<Coche> Coches { get; set; }
    }
}
