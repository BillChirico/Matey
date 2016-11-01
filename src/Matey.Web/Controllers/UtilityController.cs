using Matey.Service.UtilityServices;
using Microsoft.AspNetCore.Mvc;

namespace Matey.Web.Controllers
{
    [Route("Premises/{id}/[controller]")]
    public class UtilityController : Controller
    {
        private readonly IUtilityService _utilityService;

        public UtilityController(IUtilityService utilityService)
        {
            _utilityService = utilityService;
        }

        public ActionResult Index(int id)
        {
            return View(_utilityService.GetAll());
        }
    }
}