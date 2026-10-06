namespace WebAplicationAPIRestDemo.DAL.Model
{
    public class Dispositiu
    {
        public long Id { get; set; }
        public string Nom { get; set; }
        public long IdCategoria { get; set; }
        public string Categoria { get; set; }
        public string Estat { get; set; }
    }
}
