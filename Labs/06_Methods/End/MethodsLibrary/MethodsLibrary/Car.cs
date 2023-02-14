namespace MethodsLibrary
{
    public partial class Car
    {
        public Car()
        {
            Count++;
        }

        public static int Count { get; private set; }
        //public Make Make { get; set; }

        public bool Start()
        {
            return true;
        }
    }
}