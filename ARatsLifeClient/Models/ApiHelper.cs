using System.Threading.Tasks;
using RestSharp;

namespace ARatsLifeClient.Models
{
  public class ApiHelper
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://localhost:5102/");
      RestRequest request = new RestRequest($"api/rats", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }
  }
}