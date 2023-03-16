using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace SQLBindingsTest
{
    public static class SQLBindingsUpsertError
    {
        [FunctionName("SQLBindingsUpsertError")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "upserterror")]
            HttpRequest req, ILogger log,
            [Sql("dbo.Employees", "SqlConnectionString")]
            out Employee[] output)
        {
            output = new Employee[]
                {
                    new Employee
                    {
                        EmployeeId = 1,
                        FirstName = "Hello",
                        LastName = "World",
                        Company = "Test",
                        Department = "Random"
                        
                    }
                };

            return new CreatedResult($"/api/upserterror", output);
        }
    }
}
