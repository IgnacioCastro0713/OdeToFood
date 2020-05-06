using OdeToFood.Web.Models.ViewModels;
using System.Configuration;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class GreetingController : Controller
    {
        // GET: Greeting
        public ActionResult Index(string name)
        {
            var viewModel = new GreetingViewModel
            {
                Message = ConfigurationManager.AppSettings["message"],
                Name = name ?? "Not Name"
            };
            
            return View(viewModel);
        }
    }
}