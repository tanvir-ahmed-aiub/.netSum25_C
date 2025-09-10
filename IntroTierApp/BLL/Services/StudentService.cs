using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StudentService
    {
        public static Mapper GetMapper() {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Student, StudentDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        public static List<StudentDTO> Get() {
            var data =DataAccessFactory.StudentData().Get();
            return GetMapper().Map<List<StudentDTO>>(data);
        }
        public static List<StudentDTO> GetSch() {
            var students = DataAccessFactory.StudentData().Get();
            var data = (from s in students
                        where s.Id >= 1 && s.Id <= 5
                        select s).ToList();
            return GetMapper().Map<List<StudentDTO>>(data);
        }

        public static bool Create(StudentDTO s)
        {
            var st = GetMapper().Map<Student>(s);
            var data = DataAccessFactory.StudentData().Create(st);
            return data;
        }
        public bool IsElgbleSch(int id) { 
            var cgpa = DataAccessFactory.StudentFeature().CalculateCgpa(id);
            return cgpa >= 3.75;
        }
    }
}
