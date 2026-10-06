using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAplicationAPIRestDemo.DAL.Model;
using WebAplicationAPIRestDemo.DAL.Service;

namespace WebAplicationAPIRestDemo.Controllers
{
    [EnableCors]
    [Route("api/dispositius")]
    [ApiController]

    public class DispositiusController : Controller
    {
        // GET dispositius TOTS
        [HttpGet]
        public List<Dispositiu> Get()
        {
            DispositiuService objDispositiuService = new DispositiuService();
            return objDispositiuService.GetAll();
        }

        // GET dispositius DISPONIBLES
        [HttpGet("disponibles")]
        public List<Dispositiu> GetAv()
        {
            DispositiuService objDispositiuService = new DispositiuService();
            return objDispositiuService.GetAvailable();
        }

        // GET dispositius NO DISPONIBLES
        [HttpGet("no-disponibles")]
        public List<Dispositiu> GetNotAv()
        {
            DispositiuService objDispositiuService = new DispositiuService();
            return objDispositiuService.GetNotAvailable();
        }

        // GET dispositius EN PRESTEC
        [HttpGet("en-prestec")]
        public List<Dispositiu> GetEnPrst()
        {
            DispositiuService objDispositiuService = new DispositiuService();
            return objDispositiuService.GetEnPrestec();
        }

        // GET dispositiu ID
        [HttpGet("{id}")]
        public Dispositiu Get(int id)
        {
            DispositiuService objDispositiuService = new DispositiuService();
            return objDispositiuService.GetById(id);
        }

        // GET dispositiu
        [HttpGet("categories")]
        public List<Dispositiu> GetCategoria(int id)
        {
            DispositiuService objDispositiuService = new DispositiuService();
            return objDispositiuService.GetByIdCategoria(id);
        }

        // POST dispositiu
        [HttpPost]
        public Dispositiu Post([FromBody] Dispositiu dispositiu)
        {
            DispositiuService objDispositiuService = new DispositiuService();
            return objDispositiuService.Add(dispositiu);
        }

        // PUT dispositiu
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] Dispositiu dispositiu)
        {
            DispositiuService objDispositiuService = new DispositiuService();
            return objDispositiuService.Update(dispositiu);
        }

        // DELETE dispositiu
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DispositiuService objDispositiuService = new DispositiuService();
            objDispositiuService.Delete(id);
        }
    }
}
