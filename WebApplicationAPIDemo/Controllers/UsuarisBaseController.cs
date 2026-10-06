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
    [Route("api/usuaris-base")]
    [ApiController]

    public class UsuarisBaseController : Controller
    {
        // GET usuaris-base TOTS
        [HttpGet]
        public List<UsuariBase> Get()
        {
            UsuariBaseService objUsuariBaseService = new UsuariBaseService();
            return objUsuariBaseService.GetAll();
        }

        // DELETE usuari-base
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            UsuariBaseService objUsuariBaseService = new UsuariBaseService();
            objUsuariBaseService.Delete(id);
        }
    }
}
