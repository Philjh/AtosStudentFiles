using LendingLibrary;
using Xunit;

namespace TestProject
{
    public class UnitTest1
    {
        Library library;
        Member greta;
        Member donald;

        public UnitTest1()
        {
            library = new Library();
            greta = library.Add(name: "Greta Thunberg", age: 15);
            greta.Street = "Queen Street";
            greta.City = "Stockholm";
            greta.OutstandingFines = 25M;
            donald = donald = library.Add(name: "Donald Trump", age: 73);
            donald.Street = "Trump Tower";
            donald.City = "New York";
            donald.OutstandingFines = 2500M;
        }

        [Fact]
        public void Create()
        {


            Assert.Equal(2, library.NumberOfMembers);
            Assert.Equal(1, greta.MembershipNumber);
            Assert.Equal(2, donald.MembershipNumber);
        }

        [Fact]
        public void Child_Borrows_Child_Book_OK()
        {
            // a junior member (under 16) can borrow only child category books
            Book childBook = library.GetBook(101);
            Assert.True(greta.Borrow(childBook));
        }

        [Fact]
        public void Child_Borrows_Adult_Book_Fails()
        {
            // a junior member (under 16) can borrow only child category books
            Book adultBook = library.GetBook(100);
            Assert.False(greta.Borrow(adultBook));
        }

        [Fact]
        public void Adult_Can_Borrow_Any_Book()
        {
            // an adult member (over 16) can borrow any book
            Book adultBook = library.GetBook(100);
            Book childBook = library.GetBook(101);
            Assert.True(donald.Borrow(adultBook));
            Assert.True(donald.Borrow(childBook));
        }

        [Fact]
        public void Child_Pays_Fine_From_Cash_Fund()
        {
            greta.SetFineLimit(20M);
            greta.PayFine(7M);
            Assert.Equal(13M, greta.GetFineCredit());
        }

        [Fact]
        public void Adult_Pays_Fine_By_Bank_Transfer()
        {
            donald.SetFineLimit(20M);
            donald.PayFine(7M);
            Assert.Equal(13M, donald.GetFineCredit());
        }
    }
}