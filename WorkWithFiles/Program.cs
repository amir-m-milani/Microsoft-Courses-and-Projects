namespace WorkWithFiles;

using System.Data;
using Newtonsoft.Json;
class Program
{
    static void Main(string[] args)
    {
        /*
        System.Console.WriteLine(Directory.GetCurrentDirectory());
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        System.Console.WriteLine(docPath);
        System.Console.WriteLine(Path.DirectorySeparatorChar);

        string fileName = $"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales{Path.DirectorySeparatorChar}sales.json";

        FileInfo info = new FileInfo(fileName);

        Console.WriteLine($"Full Name: {info.FullName}{Environment.NewLine}Directory: {info.Directory}{Environment.NewLine}Extension: {info.Extension}{Environment.NewLine}Create Date: {info.CreationTime}"); // And many more
        */

        // Excercise

        //function that find files
        IEnumerable<string> FindFiles(string folderName)
        {
            List<string> salesFiles = new List<string>();
            var founFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);
            foreach (var file in founFiles)
            {
                if (Path.GetExtension(file) == ".json")
                {
                    salesFiles.Add(file);
                }
            }
            return salesFiles;
        }
        double CalculateSalesTotal(IEnumerable<string> salesFiles)
        {
            double salesTotal = 0;

            // READ FILES LOOP
            foreach (var file in salesFiles)
            {
                string salesFile = File.ReadAllText(file);
                SalesData? data = JsonConvert.DeserializeObject<SalesData?>(salesFile);
                salesTotal += data?.Total ?? 0;
            }

            return salesTotal;
        }
        /*
        var salesFiles = FindFiles(Path.Combine(Directory.GetCurrentDirectory(), "stores"));
        foreach (var file in salesFiles)
        {
            FileInfo fileInfo = new FileInfo(file);
            System.Console.WriteLine($"Full name: {fileInfo.FullName}\nfile name:{fileInfo.Name}\ncreation Time: {fileInfo.CreationTime}\n");
        }
        */
        var totalSalesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "stores", "salesTotalDir");
        Directory.CreateDirectory(totalSalesDirectory);
        var salesFiles = FindFiles(Path.Combine(Directory.GetCurrentDirectory(), "stores"));
        var salesTotal = CalculateSalesTotal(salesFiles);
        // File.WriteAllText(Path.Combine(totalSalesDirectory, "totals.txt"), string.Empty);
        File.AppendAllText(Path.Combine(totalSalesDirectory, "totals.txt"), $"total sales: {salesTotal}\n");
    }

    public class SalesData
    {
        public double Total { get; }

        public SalesData(double total)
        {
            Total = total;
        }

    }

}
