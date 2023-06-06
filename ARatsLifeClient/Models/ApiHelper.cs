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

    //--------------------------- 
    // for application users

    public static async void Post(string newApplicationUser)
    {
      RestClient client = new RestClient("http://localhost:5102/");
      RestRequest request = new RestRequest($"api/accounts", Method.Post);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newApplicationUser);
      await client.PostAsync(request);
    }
  }
}