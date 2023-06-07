using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace ARatsLifeClient.Models;

public class Item
{
  public int ItemId { get; set; }
  public string Name { get; set; }
  public int Value { get; set; }

  public static List<Item> GetItems()
  {
    var apiCallTask = ApiHelper.GetAllItems();
    var result = apiCallTask.Result;

    JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
    List<Item> itemList = JsonConvert.DeserializeObject<List<Item>>(jsonResponse.ToString());

    return itemList; 
  }

  public static Item GetItemDetails(int id)
  {
    var apiCallTask = ApiHelper.GetItemDetail(id);
    var result = apiCallTask.Result;

    JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
    Item thisItem = JsonConvert.DeserializeObject<Item>(jsonResponse.ToString());

    return thisItem;
  }
}
