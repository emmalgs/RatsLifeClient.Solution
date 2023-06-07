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

  public ActionResult Edit(int id)
  {
    Rat changeRat = Rat.GetDetails(id);
    return View(changeRat);
  }

  [HttpPost]
  public ActionResult Edit(Rat changeRat)
  {
    Rat.Put(changeRat);
    return RedirectToAction("Details", new { id = changeRat.RatId});
  }

  public ActionResult Delete(int id)
  {
    Rat deleteRat = Rat.GetDetails(id);
    return View(deleteRat);
  }

  [HttpPost, ActionName("Delete")]
  public ActionResult DeleteConfirmed(int id)
  {
    Rat.Delete(id);
    return RedirectToAction("Index");
  }

  public IActionResult AddToJourney()
  {
    return View();
  }

  [HttpPost]
  public ActionResult AddToJourney(int id)
  {
    return View();
  }
}