using System;
using System.Collections.Generic;
using System.Text;

namespace LendingLibrary
{
    // TODO Unchanged apart from name
    public class JuniorMembershipType : MembershipType
    {

        public override bool Borrow(Book book)
        {
            return (book.Category == BookCategory.Children);
        }

        decimal CashFund { get; set; }
        public override void PayFine(decimal fine)
        {
            CashFund -= fine;
        }

        public override void SetFineLimit(decimal amount)
        {
            CashFund = amount;
        }

        public override decimal GetFineCredit()
        {
            return CashFund;
        }
    }
}
