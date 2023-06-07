using System.Threading.Tasks;
using RestSharp;

namespace ARatsLifeClient.Models
{
  public class ApiHelper
  {
    // Rat functions vvv
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
      request.AddJsonBody(changeRat);
      await client.PutAsync(request);
    }

    public static async void Delete(int id)
    {
      RestClient client = new RestClient("http://localhost:5102/");
      RestRequest request = new RestRequest($"api/rats/{id}", Method.Delete);
      request.AddHeader("Content-Type", "application/json");
      await client.DeleteAsync(request);
    }

    public static async void PostJourney(int id, string storyRat)
    {
      RestClient client = new RestClient("http://localhost:5102/");
      RestRequest request = new RestRequest($"api/rats/{id}/journey", Method.Post);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(storyRat);
      await client.PostAsync(request);
    }

    public static async Task<string> GetRatJournies(int id)
    {
      RestClient client = new RestClient("http://localhost:5102/");
      RestRequest request = new RestRequest($"api/rats/{id}/journey", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async Task<string> GetRatInventory(int id)
    {
      RestClient client = new RestClient("http://localhost:5102/");
      RestRequest request = new RestRequest($"api/rats/{id}/inventories", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

// rat functions ^^^^
// ------------------------------------------
// item functions vvvv

    public static async Task<string> GetAllItems()
    {
      RestClient client = new RestClient("http://localhost:5102/");
      RestRequest request = new RestRequest($"api/items", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async Task<string> GetItemDetail(int id)
    {
      RestClient client = new RestClient("http://localhost:5102");
      RestRequest request = new RestRequest($"api/items/{id}", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }


// item functions ^^^^
// ----------------------------------
// plotpoint functions vvvv

    public static async Task<string> GetAllPlotpoints()
    {
      RestClient client = new RestClient("http://localhost:5102/");
      RestRequest request = new RestRequest($"api/plotpoints", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }
     
    public static async Task<string> GetPlotpointDetail(int id)
    {
      RestClient client = new RestClient("http://localhost:5102");
      RestRequest request = new RestRequest($"api/plotpoints/{id}", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

// plotpoint functions ^^^^
// ---------------------------------------
// choices functions vvvv


public static async Task<string> GetAllChoices()
    {
      RestClient client = new RestClient("http://localhost:5102/");
      RestRequest request = new RestRequest($"api/choices", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }
     
    public static async Task<string> GetChoiceDetail(int id)
    {
      RestClient client = new RestClient("http://localhost:5102");
      RestRequest request = new RestRequest($"api/choices/{id}", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async void PostChoice(string newChoice)
    {
      RestClient client = new RestClient("http://localhost:5102/");
      RestRequest request = new RestRequest($"api/choices", Method.Post);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newChoice);
      await client.PostAsync(request);
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