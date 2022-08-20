using System;

namespace QTSD_internship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  1 OOP
            Person person = new Person();
            person.Name = "Nguyen Hoai Nam";
            person.Age = 21;
            person.Address = "Tra Vinh";
            person.Display();

            Student student = new Student();
            student.Name = "Nguyen Hoai Viet";
            student.Age = 19;
            student.Address = "Tra Vinh";
            student.ID = "110119029";
            student.Class = "DA19TTA";
            student.Display();
        }
    }
}
