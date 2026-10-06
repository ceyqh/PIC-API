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
    [Route("api/departaments")]
    [ApiController]

    public class DepartamentsController
    {
        // GET departaments TOTS
        [HttpGet]
        public List<Departament> Get()
        {
            DepartamentService objDepartamentService = new DepartamentService();
            return objDepartamentService.GetAll();
        }

        // GET departament ID
        [HttpGet("{id}")]
        public Departament Get(int id)
        {
            DepartamentService objDepartamentService = new DepartamentService();
            return objDepartamentService.GetById(id);
        }

        // POST departament
        [HttpPost]
        public Departament Post([FromBody] Departament departament)
        {
            DepartamentService objDepartamentService = new DepartamentService();
            return objDepartamentService.Add(departament);
        }

        // PUT departament
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] Departament departament)
        {
            DepartamentService objDepartamentService = new DepartamentService();
            return objDepartamentService.Update(departament);
        }

        // DELETE departament
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DepartamentService objDepartamentService = new DepartamentService();
            objDepartamentService.Delete(id);
        }
    }
}
