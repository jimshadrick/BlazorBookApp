using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using BlazorBookLibrary;

namespace BookFunctionApi
{
    public static class BookFunction
    {
        [FunctionName("BookFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger Book Function processed a request.");

            // Create a task to return a list of books asynchronously
            var results = await Task.Run(() => GetBooks());

            return new OkObjectResult(results);
        }

        private static IEnumerable<Book> GetBooks()
            => new List<Book>
            {
                new Book(1, "Enterprise Services with the .NET Framework", "Addison Wesley"),
                new Book(2, "Professional C# 6 and .NET Core 1.0", "Wrox Press"),
                new Book(3, "Professional C# 7 and .NET Core 2.0", "Wrox Press")
            };

    }
}
