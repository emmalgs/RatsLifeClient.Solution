using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ARatsLifeClient.Models
{
  public class ApplicationUser : IdentityUser
  {
    public static void Post(ApplicationUser applicationUser)
    {
      string jsonApplicationUser = JsonConvert.SerializeObject(applicationUser);
      ApiHelper.Post(jsonApplicationUser);
    }

    public static Task<string> Login(ApplicationUser applicationUser)
    {
      string jsonApplicationUser = JsonConvert.SerializeObject(applicationUser);
      var result = ApiHelper.Login(jsonApplicationUser);
      return result;
    }
  }
}