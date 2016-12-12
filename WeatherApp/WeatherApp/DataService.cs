using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace WeatherApp
{
    public class DataService
    {
        public static async Task<JContainer> getDataFromService(string queryString)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(queryString);

            JContainer data = null;
            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result; // Smider resultatet ned i een lang streng
                data = (JContainer)JsonConvert.DeserializeObject(json); // JSON-objektet konverteres fra streng til objekt
            }

            return data;
        }
    }
}