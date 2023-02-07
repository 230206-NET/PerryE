// See https://aka.ms/new-console-template for more information
Console.WriteLine("Starting Program");
string? userInput = Console.ReadLine();
Console.WriteLine(userInput);

if (5 > 4){
Console.WriteLine("5 is greater than 4");
}
if (Int32.Parse(userInput) > 5){
Console.WriteLine($"{userInput} is greater than 5");
}
Console.WriteLine($"Ending Program");
