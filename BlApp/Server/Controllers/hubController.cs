using BlApp.Server.Hubs;
using BlApp.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAl;
using Microsoft.Extensions.DependencyInjection;
using Database;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class hubController : ControllerBase
    {

        public services.Iservices Userservis;
        public hubController(services.Iservices userservis)
        {
            Userservis = userservis;

        }
        //[HttpGet]
        //public List<messags> Get()
        //{
        //    var x =Userservis.inputM(2);
        //    var json = JsonConvert.SerializeObject(x);
        //    return x;
        //}
        [HttpPost]
        public userout login(DAl.userin user)
        {
            userout rs =new userout();
            rs.token=Userservis.login(user);
            return rs;
        }

    }
}
