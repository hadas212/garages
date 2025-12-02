using System.Net.Http.Json;
using System.Text.Json;
using GarageApi.Models;

namespace GarageApi.Services
{
    public class GovernmentApiService
    {
        private readonly HttpClient _httpClient;

        public GovernmentApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Garage>> GetGaragesFromGovAsync()
        {
            var response = await _httpClient.GetAsync(
                "https://data.gov.il/api/3/action/datastore_search?resource_id=bb68386a-a331-4bbc-b668-bba2766d517d&limit=5"
            );

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);

            var records = doc.RootElement.GetProperty("result").GetProperty("records");
            var garages = new List<Garage>();

            foreach (var item in records.EnumerateArray())
            {
                garages.Add(new Garage
                {
                    Id = item.GetProperty("_id").GetInt32(),
                    MisparMosah = item.GetProperty("mispar_mosah").GetInt32(),
                    Name = item.GetProperty("shem_mosah").GetString(),
                    CodSugMosah = item.GetProperty("cod_sug_mosah").GetInt32(),
                    SugMosah = item.GetProperty("sug_mosah").GetString(),
                    Address = item.GetProperty("ktovet").GetString(),
                    City = item.GetProperty("yishuv").GetString(),
                    Telephone = item.GetProperty("telephone").GetString(),
                    Mikud = item.GetProperty("mikud").GetInt32(),
                    CodMiktzoa = item.GetProperty("cod_miktzoa").GetInt32(),
                    Miktzoa = item.GetProperty("miktzoa").GetString(),
                    MenahelMiktzoa = item.GetProperty("menahel_miktzoa").GetString(),
                    LicenseNumber = item.GetProperty("rasham_havarot").GetInt64(),
                    Testime = item.GetProperty("TESTIME").GetString()
                });
            }

            return garages;
        }
    }
}
