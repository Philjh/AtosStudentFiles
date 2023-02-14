
namespace InterfaceProject
{
    public class AssassinatedPresident : Person
    {
        public DateTime Assassinated { get; }

        public AssassinatedPresident(string name, string address, DateTime dob, DateTime assassinated) : base(name, address, dob)
        {
            Assassinated = assassinated;
        }

    }
}
