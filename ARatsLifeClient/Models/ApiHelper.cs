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

    public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("http://localhost:5102");
      RestRequest request = new RestRequest($"api/rats/{id}", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async void Post(string newRat)
    {
      RestClient client = new RestClient("http://localhost:5102/");
      RestRequest request = new RestRequest($"api/rats", Method.Post);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newRat);
      await client.PostAsync(request);
    }

    public static async void Put(int id, string changeRat)
    {
      RestClient client = new RestClient("http://localhost:5102/");
      RestRequest request = new RestRequest($"api/rats/{id}", Method.Put);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody("changeRat");
      await client.PutAsync(request);
    }

    //--------------------------- 
    // for application users

    // public static async void Post(string newApplicationUser)
    // {
    //   RestClient client = new RestClient("http://localhost:5102/");
    //   RestRequest request = new RestRequest($"api/accounts/register", Method.Post);
    //   request.AddHeader("Content-Type", "application/json");
    //   request.AddJsonBody(newApplicationUser);
    //   await client.PostAsync(request);
    // }
    // public static async Task<string> Login(string newApplicationUser)
    // {
    //   RestClient client = new RestClient("http://localhost:5102/");
    //   RestRequest request = new RestRequest($"api/accounts/login", Method.Post);
    //   request.AddHeader("Content-Type", "application/json");
    //   request.AddJsonBody(newApplicationUser);
    //   var response = await client.PostAsync(request);
    //   return response.Content;      
    // }
  }
}