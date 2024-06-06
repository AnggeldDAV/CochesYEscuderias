namespace CochesYEscuderias.Models
{
    public class Coche
    {
        public int Id { get; set; }
        public int Motor { get; set; }
        public string Nombre { get; set; }
        public int EscuderiaId { get; set; }
    }
}
