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
                = "9856012345", PhotoPath ="person1.jpg"},
                 new Student() { Id = 2, Name = "Rohani Thapa", Email = "rohani@gmail.com", Gender = Gender.Female, Phone
                = "9856012445", PhotoPath="person2.jpg"}

            };

            /*Student std1 = new Student();
            std1.Name = "Rohan Thapa";
            std1.Email = "rohan@gmail.com";
            //......

            Student std2 = new Student();
            std2.Name = "Rohani Thapa";

            _studentList = new List<Student>();

            _studentList.Add(std1);
            _studentList.Add(std2);*/
        }
        IEnumerable<Student> IStudentRepository.GetAllStudents()
        {
            return _studentList;
        }

        public Student GetStudent(int id)
        {
            return _studentList.FirstOrDefault(student => student.Id == id);
        }
        public Student Update(Student student)
        {
            Student std = this.GetStudent(student.Id);
            if(std != null)
            {
                std.Name = student.Name;
                std.Email = student.Email;
                std.Gender = student.Gender;
                std.Phone = student.Phone;
                std.PhotoPath = student.PhotoPath;
            }
            return std;
        }
        public Student Delete(int id)
        {
            var studentToDelete = this.GetStudent(id);
            if(studentToDelete != null)
            {
                _studentList.Remove(studentToDelete);
            }
            return studentToDelete;
        }
        public Student Add(Student student)
        {
            student.Id = _studentList.Max(student => student.Id) + 1;
            _studentList.Add(student);
            return student;
        }
    }

}
