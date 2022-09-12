using Bogus;
using DataFileGenerator;
using System.Text.Json;

string[] lifeCycleStage = { "Subscriber", "Lead", "Opportunity", "Customer" };
string[] iceCreamFlavors = { "Vanilla", "Chocolate", "Coffee", "Mint Chocolate Chip" };

var data = new Faker<Profile>("en_US")
    .RuleFor(p => p.Id, p => p.Random.Guid().ToString())
    .RuleFor(p => p.FirstName, p => p.Person.FirstName)
    .RuleFor(p => p.LastName, p => p.Person.LastName)
    .RuleFor(p => p.Email, p => p.Person.Email)
    .RuleFor(p => p.Address, p => p.Address.FullAddress())
    .RuleFor(p => p.City, p => p.Address.City())
    .RuleFor(p => p.Country, p => p.Address.Country())
    .RuleFor(p => p.ZipCode, p => p.Address.ZipCode())
    .RuleFor(p => p.LifeCycleStage, p => p.PickRandom(lifeCycleStage))
    .RuleFor(p => p.ContactOwner, p => p.Person.Email)
    .RuleFor(p => p.FavoriteIceCreamFlavor, p => p.PickRandom(iceCreamFlavors))
    .Generate(40);

foreach (var item in data)
{
    Console.WriteLine(JsonSerializer.Serialize(item));
}

string directory = @$"C:\Users\{Environment.UserName}\source";

if (Directory.Exists(directory))
    Directory.CreateDirectory(directory);

//var profiles = CsvOps<Profile>.ReadCSVFile(@$"C:\Users\{Environment.UserName}\source\flatfile.csv");
CsvOps<Profile>.WriteCSVFile(@$"{directory}\ff_{DateTime.Now.Ticks}.csv", data);