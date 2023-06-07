using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace ARatsLifeClient.Models;

public class Rat
{
  public int RatId { get; set; }
  public string Name { get; set; }
  [Range(0, Int16.MaxValue, ErrorMessage = "The field {0} must be a non negative integer")]
  public int Heat { get; set; }
  public List<Inventory> ItemInventory { get; set; }
  public List<Journey> Journey { get; set; }

  public static List<Rat> GetRats()
  {
    var apiCallTask = ApiHelper.GetAll();
    var result = apiCallTask.Result;

    JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
    List<Rat> ratList = JsonConvert.DeserializeObject<List<Rat>>(jsonResponse.ToString());

    return ratList; 
  }

  public static Rat GetDetails(int id)
  {
    var apiCallTask = ApiHelper.Get(id);
    var result = apiCallTask.Result;

    JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
    Rat thisRat = JsonConvert.DeserializeObject<Rat>(jsonResponse.ToString());

    var apiCallTaskJourney = ApiHelper.GetRatJournies(id);
    var resultJourney = apiCallTaskJourney.Result;

    JArray jsonResponseJourney = JsonConvert.DeserializeObject<JArray>(resultJourney);
    List<Journey> ratsJourney = JsonConvert.DeserializeObject<List<Journey>>(jsonResponseJourney.ToString());

    foreach (Journey journey in ratsJourney)
    {
      var apiCallTaskPp = ApiHelper.GetPlotpointDetail(journey.PlotpointId);
      var resultPp = apiCallTaskPp.Result;

      JObject jsonResponsePp = JsonConvert.DeserializeObject<JObject>(resultPp);
      Plotpoint thisPp = JsonConvert.DeserializeObject<Plotpoint>(jsonResponsePp.ToString());

      journey.Plotpoint = thisPp;
    }

    thisRat.Journey = ratsJourney;
    return thisRat;
  }

    public static void Post(Rat rat)
    {
      string jsonRat = JsonConvert.SerializeObject(rat);
      ApiHelper.Post(jsonRat);
    }

    public static void Put(Rat changeRat)
    {
      string jsonRat = JsonConvert.SerializeObject(changeRat);
      ApiHelper.Put(changeRat.RatId, jsonRat);
    }

    public static void Delete(int id)
    {
      ApiHelper.Delete(id);
    }

    public static void PostRatJourney(int id, Rat storyRat)
    {
      string jsonRat = JsonConvert.SerializeObject(storyRat);
      ApiHelper.PostJourney(id, jsonRat);
    }
}