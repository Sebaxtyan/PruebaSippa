using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace PruebaTecnicaSippa.Data.Models
{
    // Clase donde declaro los atributos de la clase Employee
    public class EmpleadosAtributos
    {
        [Key] 
        public int id { get; set; }
        public string? employee_name { get; set; }
        public int employee_salary { get; set; }
        public int employee_age { get; set; }
        public string? profile_image { get; set; }
        public decimal employeeAnualSalary { get; set; }
    }

}
