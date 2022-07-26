using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;

namespace DataFileGenerator
{
    internal class CsvOps<T, TMap>
        where T : class
        where TMap : ClassMap<T>
    {
        public void WriteCSVFile(string path, List<T> collection)
        {
            using StreamWriter sw = new(path, false, new UTF8Encoding(true));
            using CsvWriter cw = new(sw, new CultureInfo("en-US"));
            cw.WriteHeader<T>();
            cw.NextRecord();
            foreach (var item in collection)
            {
                cw.WriteRecord<T>(item);
                cw.NextRecord();
            }
        }

        public List<T> ReadCSVFile(string location)
        {
            using var reader = new StreamReader(location, Encoding.Default);
            var configuration = new CsvConfiguration(new CultureInfo("en-US"));
            using var csv = new CsvReader(reader, configuration);
            var records = csv.GetRecords<T>().ToList();
            return records;
        }
    }
}
