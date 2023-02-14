using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingLibrary
{
    public class JuniorMember : Member
    {
        public JuniorMember(string name, int age, int membershipNumber) : 
            base(name, age, membershipNumber)
        {
        }
        private decimal CashFund { get; set; }// now private

        public override void SetFineLimit(decimal amount)
        {
            CashFund = amount;
        }

        public override decimal GetFineCredit()
        {
            return CashFund;
        }


        public override bool Borrow(Book book)
        {
            return (book.Category == BookCategory.Children);
        }



        public override void PayFine(decimal fine)
        {
            CashFund -= fine;
        }


    }
}
