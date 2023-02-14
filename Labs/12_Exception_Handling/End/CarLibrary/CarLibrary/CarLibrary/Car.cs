namespace CarLibrary
{
    public class Car
    {
        public Car(string make, string model)
        {
            Make = make;
            Model = model;
            validColours.Add("White");
            validColours.Add("Silver");
            validColours.Add("Black");
            validColours.Add("Red");
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
        //public int Speed
        //{
        //    get { return speed; }
        //    set {if (value > 0 && value < 100) {
        //        speed = value; } }  
        //}
        public int RoadSpeedLimit { get; set; }

        public int Speed
        {
            get { return speed; }
            set
            {
                if (value > 0 && value <= RoadSpeedLimit)
                {
                    speed = value;
                }
                else
                {
                    throw new SpeedingException(value - RoadSpeedLimit, this);
                }
            }
        }

        public string RegistrationNumber { get; set; }

        public double SpeedInKilometres => Speed * 1.609344;

        public string Make { get; set; }
        public string Model { get; set; }
        //public string Colour { get; set; }

        private List<string> validColours = new List<string>();
        
        private string colour;

        public string Colour {
            get { return colour; } 
            set { 
                if (validColours.Contains(value))
                {
                    colour = value;
                }
                else
                {
                    throw new InvalidColourException(value, this);
                }
            } 
        }

        public override string ToString()
        {
            return $"Car Make is {Make}, Model is {Model}, Colour is {Colour}, Speed is {Speed} MPH";
        }

    }
}