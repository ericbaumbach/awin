using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading;

namespace Awin_Test
{
    public class Awin
    {
        private string accessToken = ""; 
        
        private RestClient client = null;

        public Awin()
        {
            client = new RestClient("https://api.awin.com/");
        }

        private RestRequest Request(string resource, Method method, bool authenticated = true)
        {
            try
            {
                var request = new RestRequest(resource, method);

                if (authenticated)
                    request.AddHeader("Authorization", "Bearer " + accessToken);

                return request;
            }
            catch (Exception)
            {
                return new RestRequest();
            }
        }

        /// <summary>
        /// Provides a list of accounts you have access to 
        /// </summary>
        /// <returns></returns>
        public User Accounts()
        {
            try
            {
                var request = Request("accounts", Method.GET);
                var queryResult = client.Execute<User>(request).Data;

                return queryResult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Provides a list of publishers you have an active relationship with 
        /// </summary>
        /// <returns></returns>
        public List<Programme> Programmes()
        {
            try
            {
                var accountId = Accounts().accounts.FirstOrDefault().accountId;
                var request = Request($"publishers/{accountId}/programmes?relationship=joined", Method.GET);
                var queryResult = client.Execute<List<Programme>>(request).Data;

                foreach (var item in queryResult)
                {
                    item.Detail = ProgrammeDetails(item.id);

                    Thread.Sleep(10000);
                }

                return queryResult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Provides a list of publishers you have an active relationship with 
        /// </summary>
        /// <returns></returns>
        public ProgrammeDetail ProgrammeDetails(int advertiserId)
        {
            try
            {
                var accountId = Accounts().accounts.FirstOrDefault().accountId;
                var request = Request($"publishers/{accountId}/programmedetails?advertiserId={advertiserId}", Method.GET);
                var queryResult = client.Execute<ProgrammeDetail>(request).Data;

                return queryResult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Provides a list of your individual transactions
        /// </summary>
        /// <returns></returns>
        public List<Transaction> Transactions(DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                var today = DateTime.Now;

                if (startDate == null)
                    startDate = today.AddDays(-30);

                if (endDate == null)
                    endDate = today;

                startDate = TimeZoneInfo.ConvertTimeToUtc(startDate.Value);
                endDate = TimeZoneInfo.ConvertTimeToUtc(endDate.Value);

                var timeZone = "UTC";
                var accountId = Accounts().accounts.FirstOrDefault().accountId;
                var url = $"publishers/{accountId}/transactions/?startDate={startDate:yyyy-MM-ddThh:mm:ss}&endDate={endDate:yyyy-MM-ddThh:mm:ss}&timezone={timeZone}&accessToken={accessToken}";
                var request = Request(url, Method.GET, false);
                var queryResult = client.Execute<List<Transaction>>(request).Data;

                return queryResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Provides individual transactions by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Transaction Transactions(int id)
        {
            try
            {
                var timeZone = "UTC";
                var accountId = Accounts().accounts.FirstOrDefault().accountId;
                var request = Request($"publishers/{accountId}/transactions/?ids={id}&timezone={timeZone}&accessToken={accessToken}", Method.GET, false);
                var queryResult = client.Execute<Transaction>(request).Data;
                
                return queryResult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Provides information about the commissions you get from a certain programme 
        /// </summary>
        /// <returns></returns>
        public Commission CommissionGroups(int advertiserId)
        {
            try
            {
                var accountId = Accounts().accounts.FirstOrDefault().accountId;
                var request = Request($"publishers/{accountId}/commissiongroups?advertiserId={advertiserId}", Method.GET);
                var queryResult = client.Execute<Commission>(request).Data;

                return queryResult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Enables service partners to pull their commission sharing rules 
        /// </summary>
        /// <returns></returns>
        public List<CommisionRule> CommissionSharingRules()
        {
            try
            {
                var accountId = Accounts().accounts.FirstOrDefault().accountId;
                var request = Request($"publishers/{accountId}/commissionsharingrules", Method.GET);
                var queryResult = client.Execute<List<CommisionRule>>(request).Data;
             
                return queryResult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Provides aggregated reports for the advertisers you work with 
        /// </summary>
        /// <returns></returns>
        public List<ReportAggregatedByAdvertiser> ReportsAggregateByAdvertiser(DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                var today = DateTime.Now;

                if (startDate == null)
                    startDate = today.AddDays(-30);

                if (endDate == null)
                    endDate = today;

                startDate = TimeZoneInfo.ConvertTimeToUtc(startDate.Value);
                endDate = TimeZoneInfo.ConvertTimeToUtc(endDate.Value);

                var accountId = Accounts().accounts.FirstOrDefault().accountId;
                var request = Request($"publishers/{accountId}/reports/advertiser?startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}&region=BR&timezone=America/Sao_Paulo&accessToken={accessToken}", Method.GET);
                var queryResult = client.Execute<List<ReportAggregatedByAdvertiser>>(request).Data;

                return queryResult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Provides aggregated reports for the creatives you used
        /// </summary>
        /// <returns></returns>
        public List<ReportAggregatedByCreative> ReportsAggregatedByCreative(DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                var today = DateTime.Now;

                if (startDate == null)
                    startDate = today.AddDays(-30);

                if (endDate == null)
                    endDate = today;

                startDate = TimeZoneInfo.ConvertTimeToUtc(startDate.Value);
                endDate = TimeZoneInfo.ConvertTimeToUtc(endDate.Value);

                var accountId = Accounts().accounts.FirstOrDefault().accountId;
                var request = Request($"publishers/{accountId}/reports/creative?startDate={startDate:yyyy-MM-dd}&endDate={startDate:yyyy-MM-dd}&region=BR&timezone=America/Sao_Paulo&accessToken={accessToken}", Method.GET);
                var queryResult = client.Execute<List<ReportAggregatedByCreative>>(request).Data;

                return queryResult;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}