using Conditionals;

Console.WriteLine("##### If Statement #####");
var pole = Pole.North;
string animal;

if (pole == Pole.North)
{
    animal = "Polar bear";
}
else
{
    animal = "Penguin";
}
Console.WriteLine($"The animal that lives in the {pole} Pole is the {animal}");

Console.WriteLine("##### Ternary Statement #####");
pole = Pole.South;

string animal2 = (pole == Pole.North ? "Polar bear" : "Penguin");
Console.WriteLine($"The animal that lives in the {pole} Pole is the {animal2}");


Console.WriteLine("##### Switch Statement #####");
var city = CapitalCities.Madrid;
string countryMessage = "";

switch (city)
{
    case CapitalCities.Paris:
        countryMessage = $"{city} is the capital of France";
        break;
    case CapitalCities.Madrid:
        countryMessage = $"{city} is the capital of Spain";
        break;
    case CapitalCities.London:
        countryMessage = $"{city} is the capital of England";
        break;
    case CapitalCities.Rome:
        countryMessage = $"{city} is the capital of Italy";
        break;
    default:
        countryMessage = $"{city} is not a known capital city";
        break;
}
Console.WriteLine(countryMessage);



Console.WriteLine("##### Switch Expression #####");
city = CapitalCities.Paris;

countryMessage = city switch
{
    CapitalCities.Paris => $"{city} is the capital of France",

    CapitalCities.Madrid => $"{city} is the capital of Spain",

    CapitalCities.London => $"{city} is the capital of England",

    CapitalCities.Rome => $"{city} is the capital of Italy",

    _ => $"{city} is not a known capital city"

};
Console.WriteLine(countryMessage);