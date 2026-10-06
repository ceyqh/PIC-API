using Org.BouncyCastle.Crypto;

namespace WebAplicationAPIRestDemo.DAL.Model
{
    public class Administrador
    {
        public long Id{ get; set; }
        public string Nom { get; set; }
        public string Contrasenya { get; set; }
        public string Permisos { get; set; }
    }
}
