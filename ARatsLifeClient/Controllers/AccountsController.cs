using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ARatsLifeClient.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
// using ARatsLifeClient.ViewModels;

namespace ARatsLifeClient.Controllers;

  public class AccountsController : Controller
  {
    // private readonly ARatsLifeClientContext _db;
    // private readonly UserManager<ApplicationUser> _userManager;
    // private readonly SignInManager<ApplicationUser> _signInManager;

    // public AccountController (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ARatsLifeClientContext db)
    // {
    //   _userManager = userManager;
    //   _signInManager = signInManager;
    //   _db = db;
    // }

    public ActionResult Index()
    {
      return View();
    }

    public ActionResult Register()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Register(ApplicationUser applicationUser)
    {
      ApplicationUser.Post(applicationUser);
      return RedirectToAction("Index");
    }

    public ActionResult Login()
    {
      return View();
    }


    [HttpPost]
    public ActionResult Login(ApplicationUser applicationUser)
    {
      if(!ModelState.IsValid)
      {
        return View(applicationUser);
      }
      else
      {
      var result = ApplicationUser.Login(applicationUser);

      // if (result.Succeeded)
      // {

      // }
      return RedirectToAction("Index");
      }
    }
  //   [HttpPost]
  //   public async Task<ActionResult> Login(LoginViewModel model)
  //   {
  //     if (!ModelState.IsValid)
  //     {
  //       return View(model);
  //     }
  //     else
  //     {
  //       Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
  //       if (result.Succeeded)
  //       {
  //         return RedirectToAction("Index");
  //       }
  //       else
  //       {
  //         ModelState.AddModelError("", "There is something wrong with your email or username. Please try again.");
  //         return View(model);
  //       }
  //     }
  //   }

  //   [HttpPost]
  //   public async Task<ActionResult> LogOff()
  //   {
  //     await _signInManager.SignOutAsync();
  //     return RedirectToAction("Index");
  //   }
  // }
}