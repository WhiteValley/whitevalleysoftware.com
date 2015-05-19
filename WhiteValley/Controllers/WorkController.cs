using System.Web.Mvc;


namespace WhiteValley.Controllers
{
    [RoutePrefix("work"), Route("{action=index}")]
    public class WorkController : Controller
    {
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

    }
}