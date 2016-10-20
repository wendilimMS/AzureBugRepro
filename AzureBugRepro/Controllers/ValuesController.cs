namespace AzureBugRepro.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        public ValuesController(ILoggerFactory loggerFactory)
        {
            this.Logger = loggerFactory.CreateLogger(nameof(MyObject));
        }

        public ILogger Logger { get; }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] MyObject model)
        {
            this.Logger.LogAzureDiagnostics(EventIds.MyObjectCreated, "An object has been created", model);
        }
    }
}
