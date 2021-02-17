using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using UI.Context;
using UI.Model;

namespace UI.Data
{
    public class InvesmentService
    {
        IHttpClientFactory _clientFactory;
        public InvesmentService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public List<Invesment> GetInvesmentList()
        {
            using (var context = new VaultDBContext())
            {
                var invesmentList = context.Invesments.ToList();
                return invesmentList;
            }
        }
        public List<Invesment> GetInvesmentListByDate(DateTime date)
        {
            using (var context = new VaultDBContext())
            {
                var InvesmentList = context.Invesments.Where(x => x.Date.Month == date.Date.Month).ToList();
                return InvesmentList;
            }
        }

        public void InsertInvesment(InvesmentInsertModel item)
        {

            using (var context = new VaultDBContext())
            {
                Invesment Invesment = new()
                {
                    Amount = item.Amount,
                    Quantity = item.Quantity,
                    Type = item.Type.ToString(),
                    Date = item.Date.Date
                };

                context.Invesments.Add(Invesment);
                context.SaveChanges();
            }

        }

        public void DeleteInvesment(Invesment item)
        {
            using (var context = new VaultDBContext())
            {
                context.Remove(item);
                context.SaveChanges();
            }
        }

        public MBInvestment GetMBInvestments()
        {
            MBInvestment mbInvesmentList = new();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://finans.truncgil.com/today.json");
            var client = _clientFactory.CreateClient();

            var response = client.SendAsync(request).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseStream = response.Content.ReadAsStringAsync().Result;
                mbInvesmentList = JsonSerializer.Deserialize<MBInvestment>(responseStream);
            }
            mbInvesmentList.GüncellemeTarihi = DateTime.Now.ToString();
            return mbInvesmentList;
        }
    }
}
