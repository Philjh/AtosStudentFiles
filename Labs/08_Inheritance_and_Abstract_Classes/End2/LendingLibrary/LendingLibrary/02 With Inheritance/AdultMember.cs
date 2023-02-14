//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace LendingLibrary
//{
//    public class AdultMember : Member
//    {
//        public AdultMember(string name, int age, int membershipNumber) : base(name, age, membershipNumber)
//        {
//        }

//        public override bool Borrow(Book book)
//        {
//            return true;
//        }

//        public override void PayFine(decimal fine)
//        {
//            BankTransferAvailable -= fine;
//        }

//        decimal BankTransferAvailable { get; set; }  // Now private
//        public void SetUpBankTransferLimit(decimal amount)
//        {
//            BankTransferAvailable += amount;
//        }

//        public override void SetFineLimit(decimal amount)
//        {
//            SetUpBankTransferLimit(amount);
//        }

//        public override decimal GetFineCredit()
//        {
//            return BankTransferAvailable;
//        }
//    }
//}
