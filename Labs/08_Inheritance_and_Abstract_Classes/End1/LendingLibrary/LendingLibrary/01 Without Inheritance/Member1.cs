//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LendingLibrary
//{
//    public class Member
//    {
//        public decimal OutstandingFines { get; set; }
//        public string Name { get; }
//        public int MembershipNumber { get; }
//        public int Age { get; }
//        public string Street { get; set; }
//        public string City { get; set; }

//        public decimal CashFund { get; set; }

//        public void PayFine(decimal fine)
//        {
//            if (Age < 16)
//            {
//                CashFund -= fine;
//            }
//            else
//            {
//                BankTransferAvailable -= fine;
//            }
//        }

//        public decimal BankTransferAvailable { get; private set; }
//        public void SetUpBankTransferLimit(decimal amount)
//        {
//            BankTransferAvailable += amount;
//        }


//        public Member(string name, int age, int membershipNumber)
//        {
//            this.Name = name;
//            this.Age = age;
//            this.MembershipNumber = membershipNumber;
//        }

//        public bool Borrow(Book book)
//        {
//            if (Age >= 16)
//            {
//                return true;
//            }
//            else
//            {
//                return (book.Category == BookCategory.Children);
//            }
//        }
//    }
//}
