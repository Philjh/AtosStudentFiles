namespace MathsLibrary
{
    public class Calculator
    {
        public static int Add(int num1, int num2)
        {
            return num1 + num2;
        }

        // VS generated method
        //public static object Subtract(int num1, int num2)
        //{
        //    throw new NotImplementedException();
        //}


        // Edited to return an int
        // To confirm the test fails
        //public static int Subtract(int num1, int num2)
        //{
        //    throw new NotImplementedException();
        //}

        // Edited to an incorrect value
        // This confirms the logic of the failing test
        //public static int Subtract(int num1, int num2)
        //{
        //    return 0;
        //}

        // Refactored to include real implementation 
        // This confirms the logic of the passing test
        public static int Subtract(int num1, int num2)
        {
            return num1 - num2;
        }
    }
}