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
}