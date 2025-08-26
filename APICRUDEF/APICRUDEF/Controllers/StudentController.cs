using APICRUDEF.DTOs;
using APICRUDEF.EF;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APICRUDEF.Controllers
{
    [RoutePrefix("api/student")]
    public class StudentController : ApiController
    {
        Sum25_CEntities db = new Sum25_CEntities();

        public static Mapper GetMapper() {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Department, DepartmentDTO>().ReverseMap();
                cfg.CreateMap<Department, DepartmentStudentDTO>().ReverseMap();
                cfg.CreateMap<Student, StudentDTO>().ReverseMap();
                cfg.CreateMap<Student, StudentDeptDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Get()
        {
            try
            {
                //var students = db.Students.ToList();
                //var data = GetMapper().Map<List<StudentDTO>>(students);

                var data = GetMapper().Map<List<StudentDTO>>(db.Students.ToList());
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);

            }
        }
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = GetMapper().Map<StudentDTO>(db.Students.Find(id));
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);

            }
        }
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(StudentDTO s) { 
            var data = GetMapper().Map<Student>(s);
            try
            {
                db.Students.Add(data);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.Created, data);
            }
            catch (Exception ex) { 
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
