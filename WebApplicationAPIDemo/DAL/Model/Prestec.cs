using System;

namespace WebAplicationAPIRestDemo.DAL.Model
{
    public class Prestec
    {
        public int Id { get; set; }
        public string NomUsuari { get; set; }
        public int IdUsuari { get; set; }
        public string NomDispositiu{ get; set; }
        public int IdDispositiu { get; set; }
        public DateTime DataEntrega { get; set; }
        public DateTime DataRetorn { get; set; }
    }
}
