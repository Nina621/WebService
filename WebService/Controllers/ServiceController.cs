using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebService.Controllers
{
    public class ServiceController : ApiController
    {


        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "1", "123456789", "Nikolina", "Marinić", "Ž", "Slavonski Brod", "Računarstvo", "1",
                                };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "person";
        }
    }
}
