
namespace InterfaceProject
{
    public class AssassinatedPresident : Person, IComparable<AssassinatedPresident>
    {
        public DateTime Assassinated { get; }

        public AssassinatedPresident(string name, string address, DateTime dob, DateTime assassinated) : base(name, address, dob)
        {
            Assassinated = assassinated;
        }

        public int CompareTo(AssassinatedPresident? other)
        {
            if (Assassinated.Month > other.Assassinated.Month) return 1;
            if (Assassinated.Month < other.Assassinated.Month) return -1;
            return 0;
        }
    }
}
