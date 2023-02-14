using System;
using System.Collections.Generic;
using System.Text;

namespace LendingLibrary
{
    public abstract class MembershipType
    {
        public abstract bool Borrow(Book book);
        public abstract void PayFine(decimal fine);

        public abstract void SetFineLimit(decimal amount);
        public abstract decimal GetFineCredit();
    }
}
