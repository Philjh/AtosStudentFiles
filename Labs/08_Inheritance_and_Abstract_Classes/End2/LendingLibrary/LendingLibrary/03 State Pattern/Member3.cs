using System;
using System.Collections.Generic;

namespace LendingLibrary
{
    public class Member
    {
        public string Name { get; }
        public int MembershipNumber { get; }
        public int Age { get; }

        public string Street { get; set; }
        public string City { get; set; }
        public decimal OustandingFines { get; set; }

        public Member(string name, int age, int membershipNumber)
        {
            this.Name = name;
            this.Age = age;
            this.MembershipNumber = membershipNumber;
        }

        public bool Borrow(Book book) { return MembershipType.Borrow(book); }
        public void PayFine(decimal fine) { MembershipType.PayFine(fine); }

        public void SetFineLimit(decimal amount) { MembershipType.SetFineLimit(amount); }
        public decimal GetFineCredit() { return MembershipType.GetFineCredit();}

        // TODO Added a private property of MembershipType
        MembershipType MembershipType { get; set;} 

        // TODO and the ability to change MembershipType
        public void SetMembershipType(TypeOfMembership typeOfMembership)
        {
            switch(typeOfMembership)
            {
                case TypeOfMembership.Junior:
                    MembershipType = new JuniorMembershipType();
                    break;
                case TypeOfMembership.Adult:
                    MembershipType = new AdultMembershipType();
                    break;
                default: throw new Exception("Invalid Membership Type");
            }
        }
    }
}