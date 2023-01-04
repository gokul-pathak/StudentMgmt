using Infomax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infomax.Services
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudents();
    }
}
