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

    var apiCallTaskInventory = ApiHelper.GetRatInventory(id);
    var resultInventory = apiCallTaskInventory.Result;

    JArray jsonResponseInventory = JsonConvert.DeserializeObject<JArray>(resultInventory);
    List<Inventory> ratsInventory = JsonConvert.DeserializeObject<List<Inventory>>(jsonResponseInventory.ToString());

    foreach(Inventory inventory in ratsInventory)
    {
      var apiCallTaskItem = ApiHelper.GetItemDetail(inventory.ItemId);
      var resultItem = apiCallTaskItem.Result;
      
      JObject jsonResponseItem = JsonConvert.DeserializeObject<JObject>(resultItem);
      Item thisItem = JsonConvert.DeserializeObject<Item>(jsonResponseItem.ToString());

      inventory.Item = thisItem;
    }
    foreach (Journey journey in ratsJourney)
    {
      var apiCallTaskPp = ApiHelper.GetPlotpointDetail(journey.PlotpointId);
      var resultPp = apiCallTaskPp.Result;

      JObject jsonResponsePp = JsonConvert.DeserializeObject<JObject>(resultPp);
      Plotpoint thisPp = JsonConvert.DeserializeObject<Plotpoint>(jsonResponsePp.ToString());

      var apiCallTaskChoice = ApiHelper.GetChoiceDetail(journey.ChoiceId);
      var resultChoice = apiCallTaskChoice.Result;

      JObject jsonResponseChoice = JsonConvert.DeserializeObject<JObject>(resultChoice);
      Choice thisChoice = JsonConvert.DeserializeObject<Choice>(jsonResponseChoice.ToString());


      journey.Choice = thisChoice;
      journey.Plotpoint = thisPp;
    }

    thisRat.ItemInventory = ratsInventory;
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