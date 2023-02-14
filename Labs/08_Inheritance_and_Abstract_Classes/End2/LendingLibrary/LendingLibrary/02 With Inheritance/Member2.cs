//using System;
//using System.Collections.Generic;

//namespace LendingLibrary
//{
//    public abstract class Member
//    {
//        public string Name { get; }
//        public int MembershipNumber { get; }
//        public int Age { get; }

//        public string Street { get; set; }
//        public string City { get; set; }
//        public decimal OustandingFines { get; set; }

//        public Member(string name, int age, int membershipNumber)
//        {
//            this.Name = name;
//            this.Age = age;
//            this.MembershipNumber = membershipNumber;
//        }

//        public abstract bool Borrow(Book book);
//        public abstract void PayFine(decimal fine);

//        public abstract void SetFineLimit(decimal amount);
//        public abstract decimal GetFineCredit();
//    }
//}