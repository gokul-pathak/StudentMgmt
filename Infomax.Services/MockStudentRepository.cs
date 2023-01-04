using Infomax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infomax.Services
{
    public class MockStudentRepository : IStudentRepository
    {
        private List<Student> _studentList;

        public MockStudentRepository()
        {
            _studentList = new List<Student>()
            {
                new Student() { Id = 1, Name = "Rohan Thapa", Email = "rohan@gmail.com", Gender = Gender.Male, Phone
                = "9856012345"},
                 new Student() { Id = 2, Name = "Rohani Thapa", Email = "rohani@gmail.com", Gender = Gender.Female, Phone
                = "9856012445"}

            };

            /*Student std1 = new Student();
            std1.Name = "Rohan Thapa";
            std1.Email = "rohan@gmail.com";

            Student std2 = new Student();
            std2.Name = "Rohani Thapa";

            _employeeList.Add(std1);
            _employeeList.Add(std2);*/
        }
        IEnumerable<Student> IStudentRepository.GetAllStudents()
        {
            return _studentList;
        }
    }
}
