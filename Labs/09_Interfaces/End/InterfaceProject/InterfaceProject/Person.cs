

namespace InterfaceProject
{
    public class Person : IEquatable<Person> , IComparable<Person>, ICloneable<Person>
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

        public bool Equals(Person? other)
        {
            return (
                Name == other.Name &&
                Address == other.Address &&
                Dob == other.Dob
                );
        }

        public int CompareTo(Person? other)
        {
            if (Dob > other.Dob) return 1;
            if (Dob < other.Dob) return -1;
            return 0;
        }

        //public object Clone()
        //{
        //    return this.MemberwiseClone();
        //}

        public Person Clone()
        {
            return (Person)this.MemberwiseClone();
        }
    }
}
