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
    [Route("api/administradors")]
    [ApiController]

    public class AdministradorsController : Controller
    {
        // GET adminstrador TOTS
        [HttpGet]
        public List<Administrador> Get()
        {
            AdministradorService objAdministradorService = new AdministradorService();
            return objAdministradorService.GetAll();
        }

        // POST adminstrador
        [HttpPost]
        public Administrador Post([FromBody] Administrador administrador)
        {
            AdministradorService objAdministradorService = new AdministradorService();
            return objAdministradorService.Add(administrador);
        }

        // PUT adminstrador
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] Administrador administrador)
        {
            AdministradorService objAdministradorService = new AdministradorService();
            return objAdministradorService.Update(administrador);
        }

        // DELETE adminstrador
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            AdministradorService objAdministradorService = new AdministradorService();
            objAdministradorService.Delete(id);
        }
    }
}
