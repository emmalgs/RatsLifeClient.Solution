using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace ARatsLifeClient.Models;

public class Inventory
{
  public int InventoryId { get; set; }
  public int RatId { get; set; }
  public Rat Rat { get; set; }
  public int ItemId { get; set; }
  public Item Item { get; set; }

    public static List<Inventory> GetInventories(int id)
  {
    var apiCallTask = ApiHelper.GetRatInventory(id);
    var result = apiCallTask.Result;

    JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
    List<Inventory> inventoryList = JsonConvert.DeserializeObject<List<Inventory>>(jsonResponse.ToString());

    return inventoryList; 
  }
  public static void Post(Journey journey)
  {
      int id = journey.RatId;
      string jsonjourney = JsonConvert.SerializeObject(journey);
      ApiHelper.PostJourney(id, jsonjourney);
  }

}