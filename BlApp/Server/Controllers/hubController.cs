using BlApp.Server.Hubs;
using BlApp.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class hubController : ControllerBase
    {
        public ChatHub Property { get; set; }
        public  hubController()
        {
            Property = new ChatHub();
        }
        [HttpGet]
        public IEnumerable<user> Get()
        {
            
            return users.Data;
        }

    }
}
