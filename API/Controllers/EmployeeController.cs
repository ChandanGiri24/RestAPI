using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get(string id)
        {
            var emp = new EmployeeModel();

            emp = emp.FetchEmployeeDetails(id);

            if(emp!=null)
            {
                return Ok(emp);
            }
            else
            {
                return Ok("ID Not Found!");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] EmployeeModel model)
        {
            var emp = new EmployeeModel();
            
            string json = JsonSerializer.Serialize(model);
            emp.SaveEmployeeDetails(json);

            return Ok("Employee Details Saved Successfully!");
        }
    }
}
