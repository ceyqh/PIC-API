using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAplicationAPIRestDemo.DAL.Service;
using WebAplicationAPIRestDemo.DAL.Model;

namespace WebApplicationAPIRestDemo.Controllers
{
    [EnableCors]
    [Route("api/usuaris")]
    [ApiController]

    public class UsuarisController : Controller
    {
        // GET usuaris TOTS
        [HttpGet]
        public List<Usuari> Get()
        {
            UsuariService objUsuariService = new UsuariService();
            return objUsuariService.GetAll();
        }

        // GET usuari ID
        [HttpGet("{id}")]
        public Usuari Get(int id)
        {
            UsuariService objUsuariService = new UsuariService();
            return objUsuariService.GetById(id);
        }

        // GET usuaris ID CURS
        [HttpGet("cursos")]
        public List<Usuari> GetIdCurs(int id)
        {
            UsuariService objUsuariService = new UsuariService();
            return objUsuariService.GetByIdCurs(id);
        }

        // GET usuaris ID DEPARTAMENT
        [HttpGet("departaments")]
        public List<Usuari> GetIdDepartament(int id)
        {
            UsuariService objUsuariService = new UsuariService();
            return objUsuariService.GetByIdDepartament(id);
        }

        // POST usuari
        [HttpPost]
        public Usuari Post([FromBody] Usuari user)
        {
            UsuariService objUsuariService = new UsuariService();
            return objUsuariService.Add(user);
        }

        // PUT usuari
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] Usuari user)
        {
            UsuariService objUsuariService = new UsuariService();
            return objUsuariService.Update(user);
        }

        // DELETE usuari
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            UsuariService objUsuariService = new UsuariService();
            objUsuariService.Delete(id);
        }
    }
}
