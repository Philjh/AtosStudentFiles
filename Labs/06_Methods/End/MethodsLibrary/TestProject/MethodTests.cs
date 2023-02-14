using MethodsLibrary;
using Xunit;
using static MethodsLibrary.Make;

namespace TestProject
{
    public class MethodTests
    {
        [Fact]
        public void Value_And_Reference_Types_Struct()
        {
            // Create a a new public VALUE type LatLong in the MethodsLibrary project
            // Generate properties Lat and Long
            LatLong london = new LatLong() { Lat = 51.0, Long = 0.0 };
            LatLong bristol = london;
            bristol.Long -= 2.0;

            Assert.True(london.Lat == 51.0);
            Assert.True(london.Long == 0.0); // London and Bristol are two separate value types

            Assert.True(bristol.Lat == 51.0);
            Assert.True(bristol.Long == -2.0);
        }

        [Fact]
        public void Value_And_Reference_Types_Class()
        {
            // Create a a new public REFERENCE type LatLongClass in the MethodsLibrary project
            // Generate properties Lat and Long
            LatLongClass london = new LatLongClass() { Lat = 51.0, Long = 0.0 };
            LatLongClass bristol = london;
            bristol.Long -= 2.0;

            Assert.True(london.Lat == 51.0);
            Assert.True(london.Long == -2.0); // London and Bristol reference the same object

            Assert.True(bristol.Lat == 51.0);
            Assert.True(bristol.Long == -2.0);
        }

        [Fact]
        public void Null_Reference()
        {
            // Generate new reference type Car
            Car? c = null;

            bool started = false;

            // started = c.Start(); // Generate method, remove 'throw new NotImplementedException();', return true

            // Put in a not-null test, so that the car is only started if there is a car

            if (c != null)
            {
                started = c.Start();
            }
            Assert.False(started);
        }

        [Fact]
        public void Null_Reference_Resolve_By_Elvis()
        {
            Car? c = null;

            // started = c.Start();

            // Put in a not-null test using the Elvis operator, so that the car is only started if there is a car
            bool? started = c?.Start();

            Assert.Null(started); // Null assertion
        }



        [Fact]
        public void Try_Parse_Succeeds()
        {
            string input = "42";
            int result;
            // insert a call to TryParse
            int.TryParse(input, out result);
            Assert.Equal(42, result);
        }

        [Fact]
        public void Try_Parse_Succeeds_Inline_Out()
        {
            string input = "42";
            // insert a call to TryParse defining an inline out param
            int.TryParse(input, out int result);
            Assert.Equal(42, result);
        }

        [Fact]
        public void Try_Parse_Fails()
        {
            string input = "42X";
            int result;
            // Nothing to do on this test!!
            Assert.False(int.TryParse(input, out result));
        }

        [Fact]
        public void Statics()
        {
            int startCount = Car.Count;

            for (int i = 0; i < 42; i++)
            {
                new Car();
            }
            // Add a static int property Count with a public getter and a private setter
            // Create a parameterless constructor in Car and increment Count in the constructor
            Assert.Equal(42, Car.Count - startCount);
        }



        [Fact]
        public void Enums()
        {
            // Create an enum with the values Ford and BMW
            // Create a property in Car of type Make called Make
            // import the enum into this test file
            // so that you do not have to edit the code below
            Car c = new Car() { Make = Ford };
            Assert.Equal(Ford, c.Make);
        }

        // This test focuses on partial classes
        // Partial classes enable some class code to be automatically
        // generated without overwriting the developer-written code

        // Create a folder named FromDatabase in your MethodsLibrary project
        // In the folder, create a partial class Car with the same namespace as the Car at the project level
        // Make the Car at the project level also a partial class
        // Move the Make property to the 'FromDatabase' Car and add a string property called RegNumber
        // The following should then compile and the test should pass


        [Fact]
        public void Partial_Classes()
        {
            Car c = new Car() { Make = Ford, RegNumber = "ABC 123" };
            Assert.Equal(Ford, c.Make);
            Assert.Equal("ABC 123", c.RegNumber);
        }


        // We will do this in 2 stages
        // 1) Create an extension method that returns a hard-coded value
        // 2) Replace the hard-coded value with the proper code

        // 1)
        // Start by creating a public static class called ExtensionMethods
        // in which you have an extension method (extending string) called GetLengthsAsNumber1()
        // In your first attempt just return the double 3.141592

        [Fact]
        public void Extension_Methods_And_Array1()
        {                   // 3.1  4   1   5      9      2
            string ditty = @"How I wish I could recollect pi";
            Assert.Equal(3.141592, ditty.GetLengthsAsNumber1());
        }

        // 2)
        // Now, if you have time, attempt the full working version
        // Create an extension method (extending string) called GetLengthsAsNumber2()
        //
        // Use the .Split() method on string to split it into an array of words
        // Iterate round the words in the array, taking the length of each word
        // to convert 1,2,3 to one hundred and twenty three:
        // ((1 * 10) + 2) * 10 + 3
        // You will need to do this in a loop
        // And finally reduce it from 3141592 to 3.141592 by multiplying by 10 to the minus x
        //    double powerOf10 = Math.Pow(10, -(words.Length - 1));
        //    number = number * powerOf10;
        //    double result = Math.Round(number, 6);

        // Don't be at all surprised if you need to look at the worked solution!!

        [Fact]
        public void Extension_Methods_And_Array2()
        {                   // 3.1  4   1   5      9      2
            string ditty = @"How I wish I could recollect pi";
            Assert.Equal(3.141592, ditty.GetLengthsAsNumber2());
        }

    }
}
