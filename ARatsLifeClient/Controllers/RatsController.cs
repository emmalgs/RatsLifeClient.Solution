using Microsoft.AspNetCore.Mvc;
using ARatsLifeClient.Models;

namespace ARatsLifeClient.Controllers;

public class RatsController : Controller
{
  public IActionResult Index()
  {
    List<Rat> rats = Rat.GetRats();
    return View(rats);
  }

  public IActionResult Details(int id)
  {
    Rat thisRat = Rat.GetDetails(id);
    return View(thisRat);
  }

  public IActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public ActionResult Create(Rat rat)
  {
    Rat.Post(rat);
    return RedirectToAction("Index");
  }
}