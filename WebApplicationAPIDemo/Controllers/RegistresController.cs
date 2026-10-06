using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAplicationAPIRestDemo.DAL.Service;
using WebAplicationAPIRestDemo.DAL.Model;

namespace WebAplicationAPIRestDemo.Controllers
{
    [EnableCors]
    [Route("api/registres")]
    [ApiController]

    public class RegistresController
    {
        // GET registres TOTS
        [HttpGet]
        public List<Registre> Get()
        {
            RegistreService objRegistreService = new RegistreService();
            return objRegistreService.GetAll();
        }

        // GET registres ID PRESTEC
        [HttpGet("prestec")]
        public List<Registre> GetByPrestec(int id)
        {
            RegistreService objRegistreService = new RegistreService();
            return objRegistreService.GetByIdPrestec(id);
        }

        // GET registres ID DISPOSITIU
        [HttpGet("dispositiu")]
        public List<Registre> GetByDispositiu(int id)
        {
            RegistreService objRegistreService = new RegistreService();
            return objRegistreService.GetByIdDispositiu(id);
        }

        // GET registres ID GRUP
        [HttpGet("grup")]
        public List<Registre> GetByGrup(int id)
        {
            RegistreService objRegistreService = new RegistreService();
            return objRegistreService.GetByIdGrup(id);
        }

        // POST registre
        [HttpPost]
        public Registre Post([FromBody] Registre registre)
        {
            RegistreService objRegistreService = new RegistreService();
            return objRegistreService.Add(registre);
        }

        // PUT registre
        [HttpPut("{idPrestec}")]
        public int Put(int id, [FromBody] Registre registre)
        {
            RegistreService objRegistreService = new RegistreService();
            return objRegistreService.Update(registre);
        }

        // DELETE registre
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            RegistreService objRegistreService = new RegistreService();
            objRegistreService.Delete(id);
        }
    }
}
