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
    [Route("api/cursos")]
    [ApiController]

    public class CursosController : Controller
    {
        // GET: cursos TOTS
        [HttpGet]
        public List<Curs> Get()
        {
            CursService objCursService = new CursService();
            return objCursService.GetAll();
        }

        // GET curs ID
        [HttpGet("{id}")]
        public Curs Get(int id)
        {
            CursService objCursService = new CursService();
            return objCursService.GetById(id);
        }

        // POST curs
        [HttpPost]
        public Curs Post([FromBody] Curs curs)
        {
            CursService objCursService = new CursService();
            return objCursService.Add(curs);
        }

        // PUT curs
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] Curs curs)
        {
            CursService objCursService = new CursService();
            return objCursService.Update(curs);
        }

        // DELETE curs
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CursService objCursService = new CursService();
            objCursService.Delete(id);
        }
    }
}
