using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using static PruebaTecnicaSippa.Data.Models.RespuestaAtributos;


namespace PruebaTecnicaSippa.Data.Models
{

    public class EmpleadoMetodos
    {
        
        private readonly IConfiguration _configuration;

        public EmpleadoMetodos(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<EmpleadosAtributos> ObtenerDatos()
        {
            List<EmpleadosAtributos> listaEmpleados = new List<EmpleadosAtributos>();


            string apiUrl = "http://dummy.restapiexample.com/api/v1/employees";

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = Task.Run(() => httpClient.GetAsync(apiUrl)).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = Task.Run(() => response.Content.ReadAsStringAsync()).Result;   
                        ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonString);

                        List<EmpleadosAtributos> employeeDataList = apiResponse.Data;

                        foreach (var empleado in employeeDataList)
                        {
                            empleado.employeeAnualSalary = CalcularSalarioAnual(empleado.employee_salary);
                        }

                        listaEmpleados = employeeDataList;
                    }
                    else
                    {
                        Console.WriteLine($"Error en la solicitud. Código de estado: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener datos desde la URL: {ex.Message}");
            }

            return listaEmpleados;
        }

        public EmpleadosAtributos ObtenerDatoFiltrado(int id)
        {
            EmpleadosAtributos empleado = null;

            string apiUrl = $"http://dummy.restapiexample.com/api/v1/employee/{id}";

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = Task.Run(() => httpClient.GetAsync(apiUrl)).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
                        ApiResponseFilter apiResponse = JsonConvert.DeserializeObject<ApiResponseFilter>(jsonString);
                        empleado = apiResponse.Data;

                        if (empleado != null)
                        {
                            empleado.employeeAnualSalary = CalcularSalarioAnual(empleado.employee_salary);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error en la solicitud. Código de estado: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener datos desde la URL: {ex.Message}");
            }

            return empleado;
        }

        public decimal CalcularSalarioAnual(int salary)
        {
            var employeeAnualSalary = salary * 12;
            return employeeAnualSalary;
        }
    }
}

