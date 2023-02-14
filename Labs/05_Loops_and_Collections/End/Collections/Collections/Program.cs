Console.WriteLine("##### Muppet Array #####");
string[] muppets = { "Kermit the Frog", "Miss Piggy", "Fozzie Bear", "Gonzo", "Rowlf the Dog", "Scooter", "Animal", "Rizzo the Rat", "Pepe the Prawn", "Walter", "Clifford" };
foreach (var muppet in muppets)
{
    Console.WriteLine(muppet);
}

List<string> muppetsList = new List<string>();
muppetsList.AddRange(muppets);

Console.WriteLine($"The first muppet is {muppetsList[0]}");
Console.WriteLine($"The last muppet is {muppetsList[muppetsList.Count - 1]}");
Console.WriteLine("##### Add Beaker #####");
muppetsList.Add("Beaker");

Console.WriteLine($"The last muppet is {muppetsList[muppetsList.Count - 1]}");

//muppetsList.Add(true);
//muppetsList.Add(3);
Console.WriteLine("##### Before Sorting #####");
foreach(var muppet in muppetsList)
{
    Console.Write($"{muppet}, ");
}

Console.WriteLine("\n##### Sorted Muppets #####");
muppetsList.Sort();
foreach (var muppet in muppetsList)
{
    Console.Write($"{muppet}, ");
}

Console.WriteLine($"\nThe first muppet is {muppetsList[0]}");
Console.WriteLine($"The last muppet is {muppetsList[muppetsList.Count - 1]}");

Console.WriteLine("##### Index from End #####");
Console.WriteLine($"The last muppet is {muppetsList[^1]}");
Console.WriteLine($"The second to last muppet is {muppetsList[^2]}");

Console.WriteLine("##### Range #####");
var slice_56 = muppetsList.ToArray()[5..7];
foreach (var item in slice_56)
{
    Console.WriteLine(item);
}


Console.WriteLine("##### Dictionary #####");
Dictionary<string, string> muppetDict = new Dictionary<string, string>();
muppetDict.Add("Beaker", "Meep");
muppetDict.Add("Miss Piggy", "Hi-ya!");
muppetDict.Add("Kermit", "Hi-ho!");
muppetDict.Add("Cookie Monster", "Om nom nom");

string catchphrase = muppetDict["Miss Piggy"];
Console.WriteLine($"Miss Piggy's catchphrase is {catchphrase}");

Console.WriteLine("##### Dictionary KeyValue Pairs #####");
foreach (var item in muppetDict)
{
    Console.WriteLine($"Muppet: {item.Key} has the catchphrase: {item.Value}");
}

Console.WriteLine("##### Dictionary Keys #####");
foreach (var item in muppetDict.Keys)
{
    Console.WriteLine(item);
}

Console.WriteLine("##### Dictionary Values #####");
foreach (var item in muppetDict.Values)
{
    Console.WriteLine(item);
}
