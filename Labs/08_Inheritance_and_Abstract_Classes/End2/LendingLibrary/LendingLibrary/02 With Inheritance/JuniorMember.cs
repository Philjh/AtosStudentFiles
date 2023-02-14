//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace LendingLibrary
//{
//    public class JuniorMember : Member
//    {
//        public JuniorMember(string name, int age, int membershipNumber) : base(name, age, membershipNumber)
//        {
//        }

//        public override bool Borrow(Book book)
//        {
//            return (book.Category == BookCategory.Children);
//        }

//        decimal CashFund { get; set; }
//        public override void PayFine(decimal fine)
//        {
//            CashFund -= fine;
//        }

//        public override void SetFineLimit(decimal amount)
//        {
//            CashFund = amount;
//        }

//        public override decimal GetFineCredit()
//        {
//            return CashFund;
//        }
//    }
//}
