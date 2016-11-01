using Matey.Service.UtilityServices;
using Microsoft.AspNetCore.Mvc;

namespace Matey.Web.Controllers
{
    [Route("Premises/{id}/[controller]")]
    public class UtilitiesController : Controller
    {
        private readonly IUtilityService _utilityService;

        public UtilitiesController(IUtilityService utilityService)
        {
            _utilityService = utilityService;
        }

        public ActionResult Index(int id)
        {
            return View(_utilityService.GetAll());
        }
    }
}