/* -- Controllers/AccountController.cs */
using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc; 
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

// Elementos para criptografia 
using System.Security.Cryptography;
using System.Text;
using BCrypt.Net;

// Usar o banco de dados com DBUsuario e os atributos da classe usuario 
using DbUsuario = zapTito.Data.Models.Usuario; 
using Microsoft.AspNetCore.Identity.Data; 

using zapTito.Data.Models; 
using zapTito.Repositories; 

namespace zapTito.Controllers 
{
    public class AccountController 
    {
    }
}
