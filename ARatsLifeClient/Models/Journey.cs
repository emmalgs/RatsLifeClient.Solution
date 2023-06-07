using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace ARatsLifeClient.Models;
public class Journey
{
  public int JourneyId { get; set; }
  public int ChoiceId { get; set; }
  public Choice Choice { get; set; }
  public int RatId { get; set; }
  public Rat Rat { get; set; }
  public int PlotpointId { get; set; }
  public Plotpoint Plotpoint { get; set; }

  
  public static List<Journey> GetJournies(int id)
  {
    var apiCallTask = ApiHelper.GetRatJournies(id);
    var result = apiCallTask.Result;

    JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
    List<Journey> journeyList = JsonConvert.DeserializeObject<List<Journey>>(jsonResponse.ToString());

    return journeyList; 
  }
  public static void Post(Journey journey)
  {
      int id = journey.RatId;
      string jsonjourney = JsonConvert.SerializeObject(journey);
      ApiHelper.PostJourney(id, jsonjourney);
  }

}