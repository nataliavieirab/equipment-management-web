using Microsoft.AspNetCore.Mvc;

namespace EquipmentManagement.ConsoleApp.Controllers;

public class HomeController : Controller
{
  // GET: HomeController
  public ActionResult Index()
  {
    return View();
  }
}