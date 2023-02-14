using MathsLibrary;
using Xunit;

namespace Exercise2_Tests
{
    public class SimpleTests
    {
        [Fact]
        public void Add_Two_Numbers()
        {
            // Arrange  
            var num1 = 5;
            var num2 = 2;
            var expectedValue = 7;

            // Act  
            var sum = Calculator.Add(num1, num2);

            //Assert  
            Assert.Equal(expectedValue, sum);
        }

        [Fact]
        public void Add_Two_Larger_Numbers()
        {
            // Arrange  
            var num1 = 9000;
            var num2 = 2500;
            var expectedValue = 11500;

            // Act  
            var sum = Calculator.Add(num1, num2);

            //Assert  
            Assert.Equal(expectedValue, sum);
        }


        [Fact]
        public void Subtract_Two_Numbers()
        {
            // Arrange  
            var num1 = 100;
            var num2 = 25;
            var expectedValue = 75;

            // Act  
            var sum = Calculator.Subtract(num1, num2);

            //Assert  
            Assert.Equal(expectedValue, sum);
        }
    }
}
