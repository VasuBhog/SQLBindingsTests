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
    public static class SQLBindingsMaxCharError
    {
        [FunctionName("SQLBindingsMaxCharError")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "maxcharerror")]
            HttpRequest req, ILogger log,
            [Sql("dbo.Employees", "SqlConnectionString")]
            out Employee[] output)
        {
            output = new Employee[]
                {
                    new Employee
                    {
                        EmployeeId = 41,
                        FirstName = "Hello",
                        LastName = "World",
                        Company = "This is a very long string that will cause an error. This is a very long string that will cause an error. This is a very long string that will cause an error. This is a very long string that will cause an error."
                    }
                };

            return new CreatedResult($"/api/maxcharerror", output);
        }
    }
}