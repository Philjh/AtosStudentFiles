using System;
using System.Collections.Generic;
using System.Linq;

namespace LendingLibrary
{
    public class Library
    {
        Dictionary<int, Member> members = new Dictionary<int, Member>();
        Dictionary<int, Book> books = new Dictionary<int, Book>();

        public Book GetBook(int code)
        {
            return books?[code];
        }

        public Library()
        {
            books.Add(100, new Book("Walls have ears", BookCategory.Adult, 100));
            books.Add(101, new Book("Noddy goes to Toytown", BookCategory.Children, 101));
        }

        public int NumberOfMembers => members.Keys.Count;

        int GetNextFreeMembershipNumber()
        {
            return (members.Keys.Count == 0) ? 1 : members.Keys.Max() + 1;
        }

        // TODO Now we create a Member then add the appropriate MembershipType
        public Member Add(string name, int age)
        {
            Member member = new Member(name, age, GetNextFreeMembershipNumber());
            member.SetMembershipType((age < 16) ? TypeOfMembership.Junior : TypeOfMembership.Adult);
            members.Add(member.MembershipNumber, member);
            return member;
        }
    }
}