using InterfaceProject;
using System;
using System.Collections.Generic;
using Xunit;
using InterfaceProject.DUKW;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void IEquatable_Are_These_The_Same_People()
        {
            Person donald1 = new Person("Donald", "Trump Tower", new DateTime(1946, 6, 14));
            Person donald2 = new Person("Donald", "Trump Tower", new DateTime(1946, 6, 14));
            Assert.Equal(donald1, donald2);
        }

        [Fact]
        public void IEquatable_Are_These_The_Same()
        {
            Person donald1 = new Person("Donald", "trump tower", new DateTime(1946, 6, 14));
            Person donald2 = new Person("Donald", "Trump Tower", new DateTime(1946, 6, 14));
            Assert.NotEqual(donald1, donald2);
        }

        [Fact]
        public void Compare_People()
        {
            List<Person> spiceGirls = new List<Person>() {
                new Person("Baby", "Finchley", dob:new DateTime(1976, 1, 21) ),
                new Person("Posh", "Harlow", dob:new DateTime(1974, 4, 17) ),
                new Person("Ginger", "Watford", dob:new DateTime(1972, 8, 6) ),
                };

            spiceGirls.Sort();
            Assert.Equal("Ginger", spiceGirls[0].Name);
            Assert.Equal("Posh", spiceGirls[1].Name);
            Assert.Equal("Baby", spiceGirls[2].Name);
        }

        [Fact]
        public void Compare_Presidents()
        {
            List<AssassinatedPresident> assassinations = new List<AssassinatedPresident>() {
                new AssassinatedPresident("Kennedy", "Dallas", dob:new DateTime(1917, 5, 29), assassinated:new DateTime(1963, 11, 22)),
                new AssassinatedPresident("Lincoln", "Ford Theatre", dob:new DateTime(1809, 2, 12), assassinated:new DateTime(1865, 4, 15)),
                new AssassinatedPresident("Perceval", "Houses of Parliament", dob:new DateTime(1762, 11, 1), assassinated: new DateTime(1812, 5, 11)),
                };

            assassinations.Sort();
            Assert.Equal("Lincoln", assassinations[0].Name);
            Assert.Equal("Perceval", assassinations[1].Name);
            Assert.Equal("Kennedy", assassinations[2].Name);
        }

        [Fact]
        public void Clone_A_Spice_Girl()
        {
            Person baby = new Person("Baby", "Finchley", dob: new DateTime(1976, 1, 21));
            Person babyClone = baby.Clone();
            Assert.Equal(baby, babyClone);
        }

        [Fact]
        public void Evaluate_UK_Tax()
        {
            Product product = new Product(50M, new UKTaxRules(true));
            Assert.Equal(18.75M, product.GetTotalTax());
        }

        [Fact]
        public void Evaluate_US_Tax()
        {
            Product product = new Product(50M, new USTaxRules());
            Assert.Equal(7.5M, product.GetTotalTax());
        }

        [Fact]
        public void Explicit_Interfaces()
        {
            AmphibiousVehicle av = new AmphibiousVehicle();
            av.Brake();
            ((IWaterVehicle)av).Brake();
        }

    }
}