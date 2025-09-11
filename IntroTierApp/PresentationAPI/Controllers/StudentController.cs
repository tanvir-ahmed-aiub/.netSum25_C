using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PresentationAPI.Controllers
{
    [RoutePrefix("api/student")]
   
    public class StudentController : ApiController
    {
        [EnableCors("*", "*", "*")]
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Get() {
            var data = StudentService.Get();
            return Request.CreateResponse(HttpStatusCode.OK,data);
        }
        [HttpGet]
        [Route("sch")]
        public HttpResponseMessage GetSch()
        {
            var data = StudentService.GetSch();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(StudentDTO s) {
            var data = StudentService.Create(s);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }
    }
}
