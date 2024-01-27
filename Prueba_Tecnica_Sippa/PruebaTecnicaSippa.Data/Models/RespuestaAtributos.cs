using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace PruebaTecnicaSippa.Data.Models
{
    public class RespuestaAtributos
    {
        public class ApiResponse
        {
            public string Status { get; set; }
            public List<EmpleadosAtributos> Data { get; set; }
            public string Message { get; set; }
        }

        public class ApiResponseFilter
        {
            public string Status { get; set; }
            public EmpleadosAtributos Data { get; set; }
            public string Message { get; set; }
        }
    }
}
