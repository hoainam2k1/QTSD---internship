using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTSD_internship
{
    public class Student : Person
    {
        public string ID;
        public string Class;
        public Student()
        {

        }
        public Student(string id, string name, int age, string address, string Class) : base(name, age, address)
        {
            ID = id;
            Class = Class;
        }
        public override string Display()
        {
            return String.Format("Name: {0} \nAge: {1} \nAddress: {2} \nID: {3} \nClass: {4}", Name, Age, Address, ID, Class);
        }
    }
}
