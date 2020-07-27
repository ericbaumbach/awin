using Newtonsoft.Json;
using System;

namespace Awin_Test
{
    class Program
    {
        static void Main(string[] args)
        { 
            var awin = new Awin();

            Console.WriteLine($"{Environment.NewLine}--- Accounts {Environment.NewLine}");
            Console.WriteLine(JsonConvert.SerializeObject(awin.Accounts(), Formatting.Indented));
            Console.WriteLine($"{Environment.NewLine}--- Accounts {Environment.NewLine}");

            Console.WriteLine($"{Environment.NewLine}--- Programmes {Environment.NewLine}");
            Console.WriteLine(JsonConvert.SerializeObject(awin.Programmes(), Formatting.Indented));
            Console.WriteLine($"{Environment.NewLine}--- Programmes {Environment.NewLine}");

            Console.WriteLine($"{Environment.NewLine}--- Programme Details {Environment.NewLine}");
            Console.WriteLine(JsonConvert.SerializeObject(awin.ProgrammeDetails(17160), Formatting.Indented));
            Console.WriteLine($"{Environment.NewLine}--- Programme Details {Environment.NewLine}");

            Console.WriteLine($"{Environment.NewLine}--- Transactions {Environment.NewLine}");
            Console.WriteLine(JsonConvert.SerializeObject(awin.Transactions(), Formatting.Indented));
            Console.WriteLine($"{Environment.NewLine}--- Transactions {Environment.NewLine}");

            Console.WriteLine($"{Environment.NewLine}--- Transaction 700978239 {Environment.NewLine}");
            Console.WriteLine(JsonConvert.SerializeObject(awin.Transactions(700978239), Formatting.Indented));
            Console.WriteLine($"{Environment.NewLine}--- Transaction 700978239 {Environment.NewLine}");

            Console.WriteLine($"{Environment.NewLine}--- CommissionGroup 7529 {Environment.NewLine}");
            Console.WriteLine(JsonConvert.SerializeObject(awin.CommissionGroups(7529), Formatting.Indented));
            Console.WriteLine($"{Environment.NewLine}--- CommissionGroup 7529 {Environment.NewLine}");

            Console.WriteLine($"{Environment.NewLine}--- CommissionSharingRules {Environment.NewLine}");
            Console.WriteLine(JsonConvert.SerializeObject(awin.CommissionSharingRules(), Formatting.Indented));
            Console.WriteLine($"{Environment.NewLine}--- CommissionSharingRules {Environment.NewLine}");

            Console.WriteLine($"{Environment.NewLine}--- Reports Aggregate By Advertiser{Environment.NewLine}");
            Console.WriteLine(JsonConvert.SerializeObject(awin.ReportsAggregateByAdvertiser(), Formatting.Indented));
            Console.WriteLine($"{Environment.NewLine}--- Reports Aggregate By Advertiser{Environment.NewLine}");

            Console.WriteLine($"{Environment.NewLine}--- Reports Aggregated By Creative {Environment.NewLine}");
            Console.WriteLine(JsonConvert.SerializeObject(awin.ReportsAggregatedByCreative(), Formatting.Indented));
            Console.WriteLine($"{Environment.NewLine}--- Reports Aggregated By Creative {Environment.NewLine}");

            Console.ReadKey();
        }
    }
}
