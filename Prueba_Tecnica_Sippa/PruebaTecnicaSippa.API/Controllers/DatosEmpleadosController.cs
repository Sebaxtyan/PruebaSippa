using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaSippa.Data;
using PruebaTecnicaSippa.Data.Logic;

[ApiController]
[Route("api/DataAll")]
public class EmpleadoController : ControllerBase
{
    private readonly EmpleadoMetodos empleadoMetodos;

    public EmpleadoController(EmpleadoMetodos empleadoMetodos)
    {
        this.empleadoMetodos = empleadoMetodos;
    }

    [HttpGet("/Empleados")]
    public IActionResult ObtenerEmpleados()
    {
        var empleados = empleadoMetodos.ObtenerDatos();
        return Ok(empleados);
    }

    [HttpGet("/EmpleadoFiltrado")]
    public IActionResult ObtenerEmpleadoFiltrado(int id)
    {
        var empleados = empleadoMetodos.ObtenerDatoFiltrado(id);
        return Ok(empleados);
    }
}