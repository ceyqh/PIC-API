using System;

namespace WebAplicationAPIRestDemo.DAL.Model
{
    public class Registre
    {
        public long Id { get; set; }
        public int IdPrestec { get; set; }
        public string Accio { get; set; }
        public string NomUsuari { get; set; }
        public int IdUsuari { get; set; }
        public string NomDispositiu { get; set; }
        public int IdDispositiu { get; set; }
        public string NomGrup{ get; set; }
        public int IdGrup { get; set; }
        public DateTime DataAccio { get; set; }
        public DateTime DataRetorn { get; set; }
    }
}
