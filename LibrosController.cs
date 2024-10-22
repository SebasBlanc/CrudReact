using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebAPICrud.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPICrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly DbcrudTContext dbContext;

        public LibrosController(DbcrudTContext _dbContext)
        {
            dbContext = _dbContext;
        }

        [HttpGet]
        [Route("Lista")]

        public async Task<IActionResult> GetLista() { 
            var listaLibros = await dbContext.Libros.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, listaLibros);
        }


        [HttpGet]
        [Route("Obtener/{id:int}")]

        public async Task<IActionResult> GetObtener(int id)
        {
            var libros = await dbContext.Libros.FirstOrDefaultAsync(e => e.IdLibro == id);
            return StatusCode(StatusCodes.Status200OK, libros);
        }

        [HttpPost]
        [Route("Nuevo")]

        public async Task<IActionResult> NuevoLibro([FromBody] Libro objeto)
        {
            await dbContext.Libros.AddAsync(objeto);
            await dbContext.SaveChangesAsync();


            return StatusCode(StatusCodes.Status200OK, new {mensaje = "Ok" });
        }

        [HttpPut]
        [Route("Editar")]

        public async Task<IActionResult> Editar([FromBody] Libro objeto)
        {
             dbContext.Libros.Update(objeto);
            await dbContext.SaveChangesAsync();


            return StatusCode(StatusCodes.Status200OK, new { mensaje = "Ok" });
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]

        public async Task<IActionResult> Eliminar(int id)
        {
            var libros = await dbContext.Libros.FirstOrDefaultAsync(e => e.IdLibro == id);
            dbContext.Libros.Remove(libros);
            await dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, new { mensaje = "Ok" });
        }


    }

    
}
