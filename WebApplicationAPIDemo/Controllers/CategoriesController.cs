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
    [Route("api/categories")]
    [ApiController]

    public class CategoriesController : Controller
    {
        // GET categories TOTES
        [HttpGet]
        public List<Categoria> Get()
        {
            CategoriaService objCategoriaService = new CategoriaService();
            return objCategoriaService.GetAll();
        }

        // GET categoria ID
        [HttpGet("{id}")]
        public Categoria Get(int id)
        {
            CategoriaService objCategoriaService = new CategoriaService();
            return objCategoriaService.GetById(id);
        }

        // POST categoria
        [HttpPost]
        public Categoria Post([FromBody] Categoria categoria)
        {
            CategoriaService objCategoriaService = new CategoriaService();
            return objCategoriaService.Add(categoria);
        }

        // PUT categoria
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] Categoria categoria)
        {
            CategoriaService objCategoriaService = new CategoriaService();
            return objCategoriaService.Update(categoria);
        }

        // DELETE categoria
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CategoriaService objCategoriaService = new CategoriaService();
            objCategoriaService.Delete(id);
        }
    }
}
