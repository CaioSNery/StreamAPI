using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Stream.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Bem Vindo ao Stream API!✅ \n" +
                      "Acesse a documentação em /swagger para ver os endpoints disponíveis.");
        }
    }
}