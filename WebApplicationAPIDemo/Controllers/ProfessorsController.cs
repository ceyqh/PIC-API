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
    [Route("api/professors")]
    [ApiController]

    public class ProfessorsController : Controller
    {
        // GET professors TOTS
        [HttpGet]
        public List<Professor> Get()
        {
            ProfessorService objProfessorService = new ProfessorService();
            return objProfessorService.GetAll();
        }

        // GET professors ID
        [HttpGet("{id}")]
        public Professor Get(int id)
        {
            ProfessorService objProfessorService = new ProfessorService();
            return objProfessorService.GetById(id);
        }

        // POST professor
        [HttpPost]
        public Professor Post([FromBody] Professor professor)
        {
            ProfessorService objProfessorService = new ProfessorService();
            return objProfessorService.Add(professor);
        }

        // PUT professor
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] Professor professor)
        {
            ProfessorService objProfessorService = new ProfessorService();
            return objProfessorService.Update(professor);
        }

        // DELETE professor
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ProfessorService objProfessorService = new ProfessorService();
            objProfessorService.Delete(id);
        }
    }
}
