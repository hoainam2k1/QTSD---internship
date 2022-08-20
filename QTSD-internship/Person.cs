using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTSD_internship
{
    public class Person
    {
        public string Name;
        public int Age;
        public string Address;
        public Person()
        {

        }
        public Person(string name, int age, string address)
        {
            Name = name;
            Age = age;
            Address = address;
        }
        public virtual void Display()
        {
            Console.WriteLine("Name: {0} \nAge: {1} \nAddress: {2}", Name, Age, Address);
        }
        public void Create()
        {
            Console.WriteLine("Name: ?");
            Console.ReadLine();
            Console.WriteLine("Age: ?");
            Console.ReadLine();
            Console.WriteLine("Address: ?");
            Console.ReadLine();
        }
    }
}
