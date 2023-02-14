using CarLibrary;

try
{

    Car c1 = new Car();
    Console.WriteLine(nameof(c1));
    c1.Make = "Ford";
    Console.WriteLine($"Make is {c1.Make}.");
    Console.WriteLine($"Model is {c1.Model}.");

    Car c2 = new Car("Audi", "TT");
    Console.WriteLine($"Make is {c2.Make}.");
    Console.WriteLine($"Model is {c2.Model}.");
    c2.Colour = "Red";
    Console.WriteLine($"Colour is {c2.Colour}.");
    c2.RoadSpeedLimit = 50;
    c2.Speed = 30;
    Console.WriteLine($"Speed in MPH is {c2.Speed}.");
    Console.WriteLine($"Speed in KPH is {c2.SpeedInKilometres}.");

    Car c3 = new Car("BMW", "X5") { Colour = "Grey", RegistrationNumber = "ABC 123" };
    Console.WriteLine($"Make is {c3.Make}.");
    Console.WriteLine($"Model is {c3.Model}.");
    Console.WriteLine($"Colour is {c3.Colour}.");
    Console.WriteLine($"Registration is {c3.RegistrationNumber}.");

    Car c4 = new Car();
    Console.WriteLine($"Make is {c4.Make}.");
    Console.WriteLine($"Model is {c4.Model}.");
    Console.WriteLine($"Colour is {c4.Colour}.");
    Console.WriteLine($"Registration is {c4.RegistrationNumber}.");

    Car slowCar = new Car("Renault", "Clio");
    slowCar.Colour = "Black";

    slowCar.RegistrationNumber = "CLIO 1";
    slowCar.RoadSpeedLimit = 30;
    slowCar.Speed = 30;
    Console.WriteLine(slowCar.ToString());

    Car fastCar = new Car("BMW", "M5");
    fastCar.Colour = "Silver";

    fastCar.RegistrationNumber = "FAST 1";
    fastCar.RoadSpeedLimit = 70;
    fastCar.Speed = 80;
    Console.WriteLine(fastCar.ToString());
}
catch (SpeedingException ex)
{
    Console.WriteLine($"A speeding exception occurred. The car is travelling {ex.ExcessSpeed} MPH above the limit");
    Console.WriteLine($"A speeding exception occurred. Car {ex.Car.RegistrationNumber} is travelling {ex.ExcessSpeed} MPH above the limit");
}
catch (InvalidColourException ex)
{
    Console.WriteLine($"A colour exception occurred. The colour {ex.Colour} is invalid");// colour is the setter's value param
    //Console.WriteLine($"A colour exception occurred. The colour {ex.Car.Colour} is invalid");// no colour is set because it is invalid
    Console.WriteLine($"A colour exception occurred. The colour of Car {ex.Car.RegistrationNumber} is invalid");// Reg may not be set
}
catch (Exception ex)
{
    Console.WriteLine($"An exception occurred {ex.Message}");
}
finally
{
    Console.WriteLine("The finally block always runs");
}
 