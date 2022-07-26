using CsvHelper.Configuration;

namespace DataFileGenerator
{
    internal sealed class ProfileMap : ClassMap<Profile>
    {
        public ProfileMap()
        {
            Map(x => x.Id).Name("Id");
            Map(x => x.FirstName).Name("FirstName");
            Map(x => x.LastName).Name("LastName");
            Map(x => x.Email).Name("Email");
            Map(x => x.Address).Name("Address");
            Map(x => x.City).Name("City");
            Map(x => x.Country).Name("Country");
            Map(x => x.ZipCode).Name("ZipCode");
        }
    }
}
