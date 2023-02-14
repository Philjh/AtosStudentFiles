using CarLibrary;

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