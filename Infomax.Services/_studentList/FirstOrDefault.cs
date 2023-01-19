using Infomax.Models;

namespace _studentList
{
    internal class FirstOrDefault : Student
    {
        private Func<object, bool> value;

        public FirstOrDefault(Func<object, bool> value)
        {
            this.value = value;
        }
    }
}