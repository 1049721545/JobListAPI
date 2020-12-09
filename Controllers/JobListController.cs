using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobListAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JobListController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new {
                id = 1,
                isActive = true,
                title = "Fu Er Dai",
                location = "Watchtower, Washington",
                industry = "Rich",
                picture = "https://picsum.photos/300/300",
                company = "QUORDATE",
                email = "frankhorton@quordate.com",
                jobDesc = "Veniam laborum veniam commodo veniam nisi commodo. Culpa elit qui deserunt adipisicing ad dolor proident laboris adipisicing tempor eu. Elit do non occaecat exercitation ullamco deserunt. Aliquip labore consectetur elit id. Voluptate cupidatat dolore eiusmod labore eu. Consectetur ipsum mollit tempor eiusmod id ipsum sit.\r\n",
                postedOn = "2020-02-11T04:48:37 -13:00"
            });
        }
    }
}
