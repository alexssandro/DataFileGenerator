using Bogus;
using DataFileGenerator;
using System.Diagnostics;
using System.Text.Json;

string[] iceCreamFlavors = { "Vanilla", "Chocolate", "Coffee", "Mint Chocolate Chip" };
string[] jobTitles = Job.GetJobTitles();

var data = new Faker<Profile>("en_US")
    .RuleFor(p => p.Id, p => p.Random.Guid().ToString())
    .RuleFor(p => p.FirstName, p => p.Person.FirstName)
    .RuleFor(p => p.LastName, p => p.Person.LastName)
    .RuleFor(p => p.Email, p => p.Person.Email)
    .RuleFor(p => p.Address, p => p.Address.FullAddress())
    .RuleFor(p => p.City, p => p.Address.City())
    .RuleFor(p => p.Country, p => p.Address.Country())
    .RuleFor(p => p.ZipCode, p => p.Address.ZipCode("#####-####"))
    .RuleFor(p => p.FavoriteIceCreamFlavor, p => p.PickRandom(iceCreamFlavors))
    .RuleFor(p => p.PhoneNumber, p => p.Phone.PhoneNumber("###-###-####"))
    .RuleFor(p => p.JobTitle, p => p.PickRandom(jobTitles))
    .Generate(40);

foreach (var item in data)
{
    Console.WriteLine(JsonSerializer.Serialize(item));
}

//string directory = @$"C:\Users\{Environment.UserName}\desktop";
string directory = @$"C:\GeneratedData";

if (!Directory.Exists(directory))
    Directory.CreateDirectory(directory);

CsvOps<Profile>.WriteCSVFile(@$"{directory}\data_{DateTime.Now.Ticks}.csv", data);

Process.Start("explorer.exe", directory);