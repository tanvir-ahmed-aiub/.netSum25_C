using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PresentationAPI.Controllers
{
    public class RegistrationController : ApiController
    {
        [HttpPost]
        [Route("api/student/register")]
        public HttpResponseMessage Register(int sId, int secId) {
            var result = RegistrationService.Register(sId,secId);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
