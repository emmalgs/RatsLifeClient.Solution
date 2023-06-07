using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace ARatsLifeClient.Models;
public class Choice
{
  public int ChoiceId { get; set; }
  [Required(ErrorMessage = "The choice needs a decription!")]
  public string Description { get; set; }
  public int HeatLevel { get; set; } 
  public int PlotpointId { get; set; }

  public static List<Choice> GetChoices()
  {
    var apiCallTask = ApiHelper.GetAllChoices();
    var result = apiCallTask.Result;

    JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
    List<Choice> choiceList = JsonConvert.DeserializeObject<List<Choice>>(jsonResponse.ToString());

    return choiceList; 
  }

  public static Choice GetChoiceDetails(int id)
  {
    var apiCallTask = ApiHelper.GetChoiceDetail(id);
    var result = apiCallTask.Result;

    JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
    Choice thisChoice = JsonConvert.DeserializeObject<Choice>(jsonResponse.ToString());

    return thisChoice;
  }
}