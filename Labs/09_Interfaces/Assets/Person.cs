using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceProject
{
    public class Person 
    {
        public string Name { get; }
        public string Address { get; }
        public DateTime Dob { get; }

        public Person(string name, string address, DateTime dob)
        {
            Name = name;
            Address = address;
            Dob = dob;
        }
    }
}
