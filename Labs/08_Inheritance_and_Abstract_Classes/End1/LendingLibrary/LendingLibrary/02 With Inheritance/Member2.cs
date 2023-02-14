using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingLibrary
{
    public abstract class Member
    {
        public decimal OutstandingFines { get; set; }
        public string Name { get; }
        public int MembershipNumber { get; }
        public int Age { get; }
        public string Street { get; set; }
        public string City { get; set; }

        public abstract bool Borrow(Book book);
        public abstract void PayFine(decimal fine);


        public Member(string name, int age, int membershipNumber)
        {
            this.Name = name;
            this.Age = age;
            this.MembershipNumber = membershipNumber;
        }

        public abstract void SetFineLimit(decimal amount);
        public abstract decimal GetFineCredit();
    }
}
