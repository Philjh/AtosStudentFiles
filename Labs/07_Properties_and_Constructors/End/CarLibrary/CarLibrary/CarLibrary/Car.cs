namespace CarLibrary
{
    public class Car
    {
        public Car(string make, string model)
        {
            Make = make;
            Model = model;
        }

        public Car(): this("Unknown Make", "Unknown Model")
        {
            Colour = "White";
        }

        //public Car()
        //{
        //    Make = "Unknown";
        //    Model = "Unknown" ;
        //}

        private int speed; 
        public int Speed
        {
            get { return speed; }
            set {if (value > 0 && value < 100) {
                speed = value; } }  
        }

        public string RegistrationNumber { get; set; }

        public double SpeedInKilometres => Speed * 1.609344;

        public string Make { get; set; }
        public string Model { get; set; }
        public string Colour { get; set; }

    }
}