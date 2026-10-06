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
    [Route("api/prestecs")]
    [ApiController]

    public class PrestecsController : Controller
    {
        // GET: prestecs TOTS
        [HttpGet]
        public List<Prestec> Get()
        {
            PrestecService objPrestecInfoService = new PrestecService();
            return objPrestecInfoService.GetAll();
        }

        // GET prestec ID
        [HttpGet("{id}")]
        public Prestec Get(int id)
        {
            PrestecService objPrestecInfoService = new PrestecService();
            return objPrestecInfoService.GetById(id);
        }

        // GET prestecs ID DISPOSITIU
        [HttpGet("dispositius")]
        public List<Prestec> GetIdDispositiu(int id)
        {
            PrestecService objPrestecInfoService = new PrestecService();
            return objPrestecInfoService.GetByIdDispositiu(id);
        }

        // GET prestecs ID USUARI
        [HttpGet("usuaris")]
        public List<Prestec> GetIdUsuari(int id)
        {
            PrestecService objPrestecInfoService = new PrestecService();
            return objPrestecInfoService.GetByIdUsuari(id);
        }

        // POST prestec
        [HttpPost]
        public Prestec Post([FromBody] Prestec prestec)
        {
            PrestecService objPrestecAlumneService = new PrestecService();
            return objPrestecAlumneService.Add(prestec);
        }

        // PUT prestec
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] Prestec prestec)
        {
            PrestecService objPrestecAlumneService = new PrestecService();
            return objPrestecAlumneService.Update(prestec);
        }

        // DELETE prestec
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            PrestecService objPrestecAlumneService = new PrestecService();
            objPrestecAlumneService.Delete(id);
        }
    }
}
