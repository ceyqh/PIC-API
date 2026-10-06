namespace WebAplicationAPIRestDemo.DAL.Model
{
    public class Usuari
    {
        public long Id { get; set; }
        public string Nom { get; set; }
        public string Cognom { get; set; }
        public string? Tipus { get; set; }
        public string? Grup { get; set; }
        public long? IdGrup { get; set; }
    }
}
