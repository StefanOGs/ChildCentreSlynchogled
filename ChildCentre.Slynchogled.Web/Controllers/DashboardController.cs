using ChildCentre.Slynchogled.Services.Interfaces;
using ChildCentre.Slynchogled.Web.Models.Dashboard;
using Microsoft.AspNetCore.Mvc;

namespace ChildCentre.Slynchogled.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ICentreService _centreService;

        public DashboardController(ICentreService centreService)
        {
            _centreService = centreService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            DashboardModel model = new DashboardModel()
            {
                ActiveChildrenCount = _centreService.GetActiveClients().Count
            };

            return View(model);
        }
    }
}