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
    public class signController : ControllerBase
    {
        public services.Iservices Userservis;
        public signController(services.Iservices userservis)
        {
            Userservis = userservis;

        }

        [HttpPost]
        public Esignin singin(signin model)
        {
            Esignin user = Userservis.Signin(model);
            return user;
        }


    }
}
