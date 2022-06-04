using Microservices.Demo.Report.API.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Microservices.Demo.Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly ReportApplicationService reportApplicationService;

        public ReportsController(ReportApplicationService reportApplicationService)
        {
            this.reportApplicationService = reportApplicationService;
        }
        [HttpGet()]
        public async Task<ActionResult> GetAll()
        {
            return new JsonResult(await reportApplicationService.GetAllPoliciesAsync());
        }
    }
}
