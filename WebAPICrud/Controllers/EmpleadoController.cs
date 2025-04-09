using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICrud.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPICrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly DbcrudContext dbcontext;
        public EmpleadoController(DbcrudContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Get()
        {
            var listaEmpleado = await dbcontext.Empleados.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, listaEmpleado);
        }

        [HttpGet]
        [Route("Obtener/{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var empleado = await dbcontext.Empleados.FirstOrDefaultAsync(e => e.IdEmpleado == id);
            return StatusCode(StatusCodes.Status200OK, empleado);
        }

        [HttpPost]
        [Route("Nuevo")]
        public async Task<IActionResult> Nuevo([FromBody] Empleado objeto)
        {
            await dbcontext.Empleados.AddAsync(objeto);
            await dbcontext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, new { mensaje = "OK" });
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] Empleado objeto)
        {
            dbcontext.Empleados.Update(objeto);
            await dbcontext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, new { mensaje = "OK" });
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var empleado = await dbcontext.Empleados.FirstOrDefaultAsync(e => e.IdEmpleado == id);
            dbcontext.Empleados.Remove(empleado);
            await dbcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, new { mensaje = "OK" });
        }
    }
}
