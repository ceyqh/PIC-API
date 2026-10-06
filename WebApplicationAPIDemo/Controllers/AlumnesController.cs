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
    [Route("api/alumnes")]
    [ApiController]

    public class AlumnesController : Controller
    {
        // GET: alumnes TOTS
        [HttpGet]
        public List<Alumne> Get()
        {
            AlumneService objAlumneService = new AlumneService();
            return objAlumneService.GetAll();
        }

        // GET alumne ID
        [HttpGet("{id}")]
        public Alumne Get(int id)
        {
            AlumneService objAlumneService = new AlumneService();
            return objAlumneService.GetById(id);
        }

        // POST alumne
        [HttpPost]
        public Alumne Post([FromBody] Alumne alumne)
        {
            AlumneService objAlumneService = new AlumneService();
            return objAlumneService.Add(alumne);
        }

        // PUT alumnes
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] Alumne alumne)
        {
            AlumneService objAlumneService = new AlumneService();
            return objAlumneService.Update(alumne);
        }

        // DELETE alumnes
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            AlumneService objAlumneService = new AlumneService();
            objAlumneService.Delete(id);
        }
    }
}
