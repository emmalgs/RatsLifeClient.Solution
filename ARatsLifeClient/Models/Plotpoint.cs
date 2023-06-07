using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ARatsLifeClient.Models;
public class Plotpoint
{
  public int PlotpointId { get; set; }
  [Required(ErrorMessage = "The plotpoint needs a title!")]
  public string Title { get; set; }
  [Required(ErrorMessage = "The plotpoint needs a description!")]
  public string Description { get; set; }
  public int StoryPosition { get; set; }
  public List<Choice> Choices { get; set; }

  public static List<Plotpoint> GetPlotpoints()
  {
    var apiCallTask = ApiHelper.GetAllPlotpoints();
    var result = apiCallTask.Result;

    JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
    List<Plotpoint> plotpointList = JsonConvert.DeserializeObject<List<Plotpoint>>(jsonResponse.ToString());

    return plotpointList; 
  }

  public static Plotpoint GetPlotpointDetails(int id)
  {
    var apiCallTask = ApiHelper.GetPlotpointDetail(id);
    var result = apiCallTask.Result;

    JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
    Plotpoint thisPlotpoint = JsonConvert.DeserializeObject<Plotpoint>(jsonResponse.ToString());

    return thisPlotpoint;
  }
}