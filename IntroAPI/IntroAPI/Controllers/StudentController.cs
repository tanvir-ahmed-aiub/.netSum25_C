using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntroAPI.Controllers
{
    [RoutePrefix("api/student")]
    public class StudentController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAll() { 
            return Request.CreateResponse(HttpStatusCode.OK,"All Students");
        }
        [HttpGet]
        [Route("details/{s_id}")]
        public HttpResponseMessage Get(int s_id) {
            return Request.CreateResponse(HttpStatusCode.OK, "Students "+s_id);
        }
        [HttpGet]
        [Route("probation")]
        public HttpResponseMessage Probation() {
            return Request.CreateResponse(HttpStatusCode.OK, "Probation Students");
        }
        [HttpGet]
        [Route("scholarship")]
        public HttpResponseMessage Scholarship()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "scholarship Students");
        }

    }
}
