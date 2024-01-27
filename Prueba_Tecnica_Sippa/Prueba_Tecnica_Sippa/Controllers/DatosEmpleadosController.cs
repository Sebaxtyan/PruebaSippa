using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaSippa.Data.Models;
using Microsoft.Extensions.Configuration;

[ApiController]
[Route("api/[controller]")]
public class EmpleadoController : ControllerBase
{
    public readonly IConfiguration configuration;

    public EmpleadoController(IConfiguration configuration)
    {
     this.configuration = configuration;
    }

    [HttpGet]
    public IActionResult ObtenerEmpleados()
    {
        EmpleadoMetodos Datos = new EmpleadoMetodos(this.configuration);
        var ResultEmployeeAll = Datos.ObtenerDatos();
        return Ok(ResultEmployeeAll);
    }

    [HttpGet("{id}")]
    public IActionResult ObtenerEmpleadoFiltrado(int id)
    {
        EmpleadoMetodos Datos = new EmpleadoMetodos(this.configuration);
        var ResultEmployee = Datos.ObtenerDatoFiltrado(id);

        if (ResultEmployee == null)
        {
            Console.WriteLine($"No se encontró ningún empleado con el ID: {id}");
            return NotFound();
        }


        return Ok(ResultEmployee);
    }
}